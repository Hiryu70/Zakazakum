using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;
using Zakazakum.Domain.Entities;

namespace Zakazakum.Application.Orders.Commands.AddFoodOrder
{
	public class AddFoodOrderCommandHandler : IRequestHandler<AddFoodOrderCommand>
	{
		private readonly IZakazakumContext _context;

		public AddFoodOrderCommandHandler(IZakazakumContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(AddFoodOrderCommand request, CancellationToken cancellationToken)
		{
			var order = await _context.Orders
				.Include(o => o.UserOrders)
				.ThenInclude(uo => uo.FoodOrders)
				.FirstAsync(o => o.Id == request.OrderId);
			var user = await _context.Users.FirstAsync(u => u.Id == request.FoodOrder.UserId);

			var food = order.Restaurant.Foods.First(f => f.Id == request.FoodOrder.FoodId);
			var comment = string.IsNullOrEmpty(request.FoodOrder.Comment?.Trim()) 
				? null 
				: request.FoodOrder.Comment?.Trim();
			var foodOrder = new FoodOrder
			{
				Food = food,
				Count = request.FoodOrder.Count,
				Comment = comment
			};

			var userOrder = order.UserOrders?.FirstOrDefault(o => o.User == user);
			if (userOrder == null)
			{
				if (order.UserOrders == null)
				{
					order.UserOrders = new List<UserOrder>();
				}

				userOrder = new UserOrder()
				{
					User = user,
					FoodOrders = new List<FoodOrder>{ foodOrder }
				};
				order.UserOrders.Add(userOrder);
			}
			else
			{
				userOrder.FoodOrders.Add(foodOrder);
			}

			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
