using MediatR;

namespace Zakazakum.Application.Orders.Commands.UpdateDeliveryCost
{
	public class UpdateDeliveryCostCommand : IRequest
	{
		public int OrderId { get; set; }

		public float DeliveryCost { get; set; }
	}
}
