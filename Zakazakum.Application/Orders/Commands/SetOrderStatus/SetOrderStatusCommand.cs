using MediatR;
using Zakazakum.Domain.Enums;

namespace Zakazakum.Application.Orders.Commands.SetOrderStatus
{
	public class SetOrderStatusCommand : IRequest
	{
		public int OrderId { get; set; }

		public OrderStatus OrderStatus { get; set; }
	}
}
