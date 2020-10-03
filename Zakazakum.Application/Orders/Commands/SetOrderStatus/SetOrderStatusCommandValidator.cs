using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Orders.Commands.SetOrderStatus
{
	public class SetOrderStatusCommandValidator : AbstractValidator<SetOrderStatusCommand>
	{
		private readonly IZakazakumContext _context;

		public SetOrderStatusCommandValidator(IZakazakumContext context)
		{
			_context = context;
			RuleFor(x => x.OrderId).MustAsync(OrderExists)
				.WithMessage("Заказ не найден.");
		}

		private async Task<bool> OrderExists(SetOrderStatusCommand command, int orderId, CancellationToken cancellationToken)
		{
			var order = await _context.Orders.FirstOrDefaultAsync(r => r.Id == orderId);

			if (order != null)
			{
				return true;
			}

			return false;
		}
	}
}
