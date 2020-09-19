using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Orders.Commands.AddFoodOrder
{
	public class UpdateFoodOrderCommandValidator : AbstractValidator<UpdateFoodOrderCommand>
	{
		private readonly IZakazakumContext _context;

		public UpdateFoodOrderCommandValidator(IZakazakumContext context)
		{
			_context = context;
			RuleFor(x => x.OrderId).MustAsync(OrderExists)
				.WithMessage("Заказ не найден.");
			RuleFor(x => x.FoodOrder.FoodId).MustAsync(FoodExist)
				.WithMessage("Блюдо не найдено.");
			RuleFor(x => x.FoodOrder.UserId).MustAsync(UserExists)
				.WithMessage("Пользователь не найден.");
		}

		private async Task<bool> OrderExists(UpdateFoodOrderCommand command, int orderId, CancellationToken cancellationToken)
		{
			var orders = await _context.Orders.ToListAsync(cancellationToken);
			var order = orders.FirstOrDefault(r => r.Id == orderId);

			if (order != null)
			{
				return true;
			}

			return false;
		}

		private async Task<bool> FoodExist(UpdateFoodOrderCommand command, Guid foodId, CancellationToken cancellationToken)
		{
			var order = await _context.Orders
				.Include(o => o.Restaurant)
				.Include(o => o.Restaurant.Foods)
				.FirstOrDefaultAsync(r => r.Id == command.OrderId);

			var restrauntFoodIds = order?.Restaurant.Foods.Select(f => f.Id == foodId);
			if (restrauntFoodIds == null)
				return false;

			return true;
		}

		private async Task<bool> UserExists(UpdateFoodOrderCommand command, Guid userId, CancellationToken cancellationToken)
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
