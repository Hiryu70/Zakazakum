using System;

namespace Zakazakum.Application.Orders.Commands.AddFoodOrder
{
	public class AddFoodOrderVm
	{
		public Guid Id { get; set; }

		public Guid FoodId { get; set; }

		public Guid UserId { get; set; }

		public int Count { get; set; }

		public string Comment { get; set; }
	}
}
