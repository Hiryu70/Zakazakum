using System;
using System.Collections.Generic;

namespace Zakazakum.Domain.Entities
{
	public class Order
	{
		public Guid Id { get; set; }

		public Restaurant Restaurant { get; set; }

		public List<UserOrder> UserOrders { get; set; }

		public float DeliveryCost { get; set; }
	}
}
