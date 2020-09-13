using MediatR;

namespace Zakazakum.Application.Orders.Queries.GetOrder
{
	public class GetOrderQuery : IRequest<GetOrderVm>
	{
		public int OrderId { get; set; }
	}
}
