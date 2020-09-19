using MediatR;

namespace Zakazakum.Application.Orders.Commands.AddFoodOrder
{
	public class UpdateFoodOrderCommand : IRequest
	{
		public int OrderId { get; set; }
		
		public UpdateFoodOrderVm FoodOrder { get; set; }
	}
}
