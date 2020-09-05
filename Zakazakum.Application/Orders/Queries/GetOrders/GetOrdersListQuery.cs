using MediatR;

namespace Zakazakum.Application.Orders.Queries.GetOrders
{
	public class GetOrdersListQuery : IRequest<OrdersListVm>
	{
	}
}
