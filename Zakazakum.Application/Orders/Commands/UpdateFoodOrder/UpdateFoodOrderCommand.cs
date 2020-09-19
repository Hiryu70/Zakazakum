using MediatR;

namespace Zakazakum.Application.Orders.Commands.UpdateFoodOrder
{
	public class UpdateFoodOrderCommand : IRequest
	{
		public int OrderId { get; set; }

		public UpdateFoodOrderVm FoodOrder { get; set; }
	}
}
