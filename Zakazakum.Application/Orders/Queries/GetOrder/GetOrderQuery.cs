using MediatR;

namespace Zakazakum.Application.Orders.Queries.GetOrder
{
	public class GetOrderQuery : IRequest<OrderVm>
	{
		public int OrderId { get; set; }
	}
}
