using System;
using MediatR;
using Zakazakum.Application.Restraunts.Commands.AddFood;

namespace Zakazakum.Application.Orders.Commands.AddFoodOrder
{
	public class AddFoodCommand : IRequest
	{
		public Guid RestaurantId { get; set; }
		
		public AddFoodVm Food { get; set; }
	}
}
