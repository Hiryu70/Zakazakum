using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Orders.Commands.DeleteFoodOrder
{
	public class DeleteFoodOrderCommandHandler : IRequestHandler<DeleteFoodOrderCommand>
	{
		private readonly IZakazakumContext _context;

		public DeleteFoodOrderCommandHandler(IZakazakumContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(DeleteFoodOrderCommand request, CancellationToken cancellationToken)
		{
			var order = await _context.Orders
				.Include(o => o.UserOrders)
				.ThenInclude(uo => uo.FoodOrders)
				.FirstAsync(o => o.Id == request.OrderId);
			var user = await _context.Users.FirstAsync(u => u.Id == request.FoodOrder.UserId);
			var userOrder = order.UserOrders?.FirstOrDefault(o => o.User == user);
			var foodOrder = userOrder.FoodOrders.FirstOrDefault(fo => fo.Id == request.FoodOrder.Id);

			userOrder.FoodOrders.Remove(foodOrder);

			if (!userOrder.FoodOrders.Any())
			{
				order.UserOrders.Remove(userOrder);
			}

			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
