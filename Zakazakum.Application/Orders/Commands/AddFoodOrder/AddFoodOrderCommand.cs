﻿using System.Collections.Generic;
using MediatR;

namespace Zakazakum.Application.Orders.Commands.AddFoodOrder
{
	public class AddFoodOrderCommand : IRequest
	{
		public int OrderId { get; set; }
		
		public List<FoodOrderVm> FoordOrders { get; set; }
	}
}