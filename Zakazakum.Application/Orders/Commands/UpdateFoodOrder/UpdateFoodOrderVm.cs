using System;

namespace Zakazakum.Application.Orders.Commands.UpdateFoodOrder
{
	public class UpdateFoodOrderVm
	{
		public Guid Id { get; set; }

		public Guid FoodId { get; set; }

		public Guid UserId { get; set; }

		public int Count { get; set; }

		public string Comment { get; set; }
	}
}
