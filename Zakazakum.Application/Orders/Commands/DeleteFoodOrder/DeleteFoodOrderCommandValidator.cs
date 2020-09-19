using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Orders.Commands.DeleteFoodOrder
{
	public class DeleteFoodOrderCommandValidator : AbstractValidator<DeleteFoodOrderCommand>
	{
		private readonly IZakazakumContext _context;

		public DeleteFoodOrderCommandValidator(IZakazakumContext context)
		{
			_context = context;
			RuleFor(x => x.OrderId).MustAsync(OrderExists)
				.WithMessage("Заказ не найден.");
			RuleFor(x => x.FoodOrder.UserId).MustAsync(UserExists)
				.WithMessage("Пользователь не найден.");
		}

		private async Task<bool> OrderExists(DeleteFoodOrderCommand command, int orderId, CancellationToken cancellationToken)
		{
			var orders = await _context.Orders.ToListAsync(cancellationToken);
			var order = orders.FirstOrDefault(r => r.Id == orderId);

			if (order != null)
			{
				return true;
			}

			return false;
		}

		private async Task<bool> UserExists(DeleteFoodOrderCommand command, Guid userId, CancellationToken cancellationToken)
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
