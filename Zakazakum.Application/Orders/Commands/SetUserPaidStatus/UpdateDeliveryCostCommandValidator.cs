using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Orders.Commands.UpdateDeliveryCost
{
	public class SetUserPaidStatusCommandValidator : AbstractValidator<SetUserPaidStatusCommand>
	{
		private readonly IZakazakumContext _context;

		public SetUserPaidStatusCommandValidator(IZakazakumContext context)
		{
			_context = context;
			RuleFor(x => x.OrderId).MustAsync(OrderExists)
				.WithMessage("Заказ не найден.");
			RuleFor(x => x.UserId).MustAsync(UserExists)
				.WithMessage("Пользователь не найден.");
		}

		private async Task<bool> OrderExists(SetUserPaidStatusCommand command, int orderId, CancellationToken cancellationToken)
		{
			var order = await _context.Orders.FirstOrDefaultAsync(r => r.Id == orderId);

			if (order != null)
			{
				return true;
			}

			return false;
		}

		private async Task<bool> UserExists(SetUserPaidStatusCommand command, Guid userId, CancellationToken cancellationToken)
		{
			var user = await _context.Users.FirstOrDefaultAsync(r => r.Id == userId);

			if (user != null)
			{
				return true;
			}

			return false;
		}
	}
}
