using System;

namespace Zakazakum.Domain.Entities
{
	public class FoodOrder
	{
		public Guid Id { get; set; }

		public Food Food { get; set; }

		public int Count { get; set; }

		public string Comment { get; set; }
	}
}
