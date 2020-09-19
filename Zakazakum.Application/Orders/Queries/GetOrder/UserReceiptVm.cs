using System;

namespace Zakazakum.Application.Orders.Queries.GetOrder
{
	public class UserReceiptVm
	{
		public Guid UserId { get; set; }

		public string Name { get; set; }

		public float Total { get; set; }

		public float FoodCost { get; set; }

		public float DeliveryCost { get; set; }

		public bool IsOrderPaid { get; set; }
	}
}
