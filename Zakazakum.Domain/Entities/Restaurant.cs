using System;
using System.Collections.Generic;

namespace Zakazakum.Domain.Entities
{
	public class Restaurant
	{
		public Guid Id { get; set; }

		public string Title { get; set; }

		public List<Food> Foods { get; set; }
	}
}
