using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Orders.Commands.AddFoodOrder
{
	public class AddFoodOrderCommandValidator : AbstractValidator<AddFoodOrderCommand>
	{
		private readonly IZakazakumContext _context;

		public AddFoodOrderCommandValidator(IZakazakumContext context)
		{
			_context = context;
			RuleFor(x => x.OrderId).MustAsync(OrderExists)
				.WithMessage("Не найден заказ с указанным идентификатором");
			RuleFor(x => x.FoodOrders).MustAsync(FoodsExist)
				.WithMessage("Не найдено блюдо с указанным идентификатором");
		}

		private async Task<bool> OrderExists(AddFoodOrderCommand command, int orderId, CancellationToken cancellationToken)
		{
			var orders = await _context.Orders.ToListAsync(cancellationToken);
			var order = orders.FirstOrDefault(r => r.Id == orderId);

			if (order != null)
			{
				return true;
			}

			return false;
		}

		private async Task<bool> FoodsExist(AddFoodOrderCommand command, List<FoodOrderVm> foodOrders, CancellationToken cancellationToken)
		{
			var foodExist = true;
			var orders = await _context.Orders
				.Include(o => o.Restaurant)
				.Include(o => o.Restaurant.Foods)
				.ToListAsync(cancellationToken);
			var order = orders.FirstOrDefault(r => r.Id == command.OrderId);

			var restrauntFoodIds = order?.Restaurant.Foods.Select(f => f.Id).ToList();
			if (restrauntFoodIds == null)
				return false;

			foreach (FoodOrderVm foodOrder in foodOrders)
			{
				if (!restrauntFoodIds.Contains(foodOrder.FoodId))
				{
					foodExist = false;
				}
			}

			return foodExist;
		}
	}
}
