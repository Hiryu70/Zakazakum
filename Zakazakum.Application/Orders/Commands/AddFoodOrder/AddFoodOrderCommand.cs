﻿using MediatR;

namespace Zakazakum.Application.Orders.Commands.AddFoodOrder
{
	public class AddFoodOrderCommand : IRequest
	{
		public int OrderId { get; set; }
		
		public AddFoodOrderVm FoodOrder { get; set; }
	}
}
