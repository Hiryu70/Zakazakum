using System;

namespace Zakazakum.Application.Orders.Queries.GetOrder
{
	public class GetFoodOrderVm
	{
		public Guid FoodOrderId { get; set; }

		public Guid FoodId { get; set; }

		public float Cost { get; set; }

		public string Title { get; set; }

		public string Comment { get; set; }

		public int Count { get; set; }

		public Guid UserId { get; set; }

		public string UserName { get; set; }
	}
}
