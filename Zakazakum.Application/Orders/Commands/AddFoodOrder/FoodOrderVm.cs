using System;

namespace Zakazakum.Application.Orders.Commands.AddFoodOrder
{
	public class FoodOrderVm
	{
		public Guid Id { get; set; }

		public Guid FoodId { get; set; }

		public int Count { get; set; }

		public string Comment { get; set; }
	}
}
