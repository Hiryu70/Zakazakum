using System;

namespace Zakazakum.Domain.Entities
{
	public class Food
	{
		public Guid Id { get; set; }

		public string Title { get; set; }

		public float Cost { get; set; }

		public string Description { get; set; }
	}
}
