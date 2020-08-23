using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Orders.Commands.UpdateDeliveryCost
{
	public class UpdateDeliveryCostCommandValidator : AbstractValidator<UpdateDeliveryCostCommand>
	{
		private readonly IZakazakumContext _context;

		public UpdateDeliveryCostCommandValidator(IZakazakumContext context)
		{
			_context = context;
			RuleFor(x => x.OrderId).MustAsync(OrderExists)
				.WithMessage("Не найден ресторан с указанным идентификатором");
			RuleFor(x => x.DeliveryCost).GreaterThanOrEqualTo(0);
		}

		private async Task<bool> OrderExists(UpdateDeliveryCostCommand command, int orderId, CancellationToken cancellationToken)
		{
			var orders = await _context.Orders.ToListAsync(cancellationToken);
			var order = orders.FirstOrDefault(r => r.Id == orderId);

			if (order != null)
			{
				return true;
			}

			return false;
		}
	}
}
