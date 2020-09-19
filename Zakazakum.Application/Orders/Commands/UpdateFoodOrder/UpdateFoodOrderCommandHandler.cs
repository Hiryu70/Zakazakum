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
	public class UpdateFoodOrderCommandHandler : IRequestHandler<UpdateFoodOrderCommand>
	{
		private readonly IZakazakumContext _context;

		public UpdateFoodOrderCommandHandler(IZakazakumContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(UpdateFoodOrderCommand request, CancellationToken cancellationToken)
		{
			var order = await _context.Orders
				.Include(o => o.UserOrders)
				.ThenInclude(uo => uo.FoodOrders)
				.FirstAsync(o => o.Id == request.OrderId);
			var user = await _context.Users.FirstAsync(u => u.Id == request.FoodOrder.UserId);

			var food = order.Restaurant.Foods.First(f => f.Id == request.FoodOrder.FoodId);

			var userOrder = order.UserOrders?.FirstOrDefault(o => o.User == user);
			var foodOrder = userOrder.FoodOrders.FirstOrDefault(fo => fo.Id == request.FoodOrder.Id);

			foodOrder.Food = food;
			foodOrder.Count = request.FoodOrder.Count;
			foodOrder.Comment = request.FoodOrder.Comment;

			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
