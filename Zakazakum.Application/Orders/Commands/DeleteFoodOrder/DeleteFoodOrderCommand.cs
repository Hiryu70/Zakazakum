using MediatR;

namespace Zakazakum.Application.Orders.Commands.DeleteFoodOrder
{
	public class DeleteFoodOrderCommand : IRequest
	{
		public int OrderId { get; set; }

		public DeleteFoodOrderVm FoodOrder { get; set; }
	}
}
