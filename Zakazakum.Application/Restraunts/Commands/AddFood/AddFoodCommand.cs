using System;
using MediatR;
using Zakazakum.Application.Restraunts.Common;

namespace Zakazakum.Application.Orders.Commands.AddFoodOrder
{
	public class AddFoodCommand : IRequest
	{
		public Guid RestaurantId { get; set; }
		
		public FoodVm Food { get; set; }
	}
}
