using System;
using System.Collections.Generic;
using Zakazakum.Domain.Enums;

namespace Zakazakum.Domain.Entities
{
	public class Order
	{
		public int Id { get; set; }

		public OrderStatus OrderStatus { get; set; }

		public User Owner { get; set; }

		public DateTime Created { get; set; }

		public Restaurant Restaurant { get; set; }

		public List<UserOrder> UserOrders { get; set; }

		public float DeliveryCost { get; set; }
	}
}
