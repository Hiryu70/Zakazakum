using MediatR;
using Zakazakum.Domain.Enums;

namespace Zakazakum.Application.Orders.Queries.GetOrders
{
	public class GetOrdersListQuery : IRequest<OrdersListVm>
	{
		public OrderStatus? OrderStatus { get; set; }
	}
}
