﻿using System;

namespace Zakazakum.Application.Orders.Commands.AddFoodOrder
{
	public class FoodOrderVm
	{
		public Guid FoodId { get; set; }

		public Guid UserId { get; set; }

		public int Count { get; set; }

		public string Comment { get; set; }
	}
}
