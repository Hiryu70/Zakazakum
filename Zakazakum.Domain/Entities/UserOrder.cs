using System;
using System.Collections.Generic;

namespace Zakazakum.Domain.Entities
{
	public class UserOrder
	{
		public Guid Id { get; set; }

		public User User { get; set; }

		public List<FoodOrder> FoodOrders { get; set; }

		public bool IsOrderPaid { get; set; }
	}
}
