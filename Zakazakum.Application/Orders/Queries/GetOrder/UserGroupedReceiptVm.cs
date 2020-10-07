using System;
using System.Collections.Generic;

namespace Zakazakum.Application.Orders.Queries.GetOrder
{
	public class UserGroupedReceiptVm
	{
		public Guid UserId { get; set; }

		public string Name { get; set; }

		public float Total { get; set; }

		public float FoodCost { get; set; }

		public float DeliveryCost { get; set; }

		public bool IsOrderPaid { get; set; }

		public List<GetFoodOrderVm> FoodOrders {get;set;}
	}
}
