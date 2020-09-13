using System.Collections.Generic;

namespace Zakazakum.Application.Orders.Queries.GetOrders
{
	public class OrdersListVm
	{
		public IList<GetOrdersVm> Orders { get; set; }
	}
}
