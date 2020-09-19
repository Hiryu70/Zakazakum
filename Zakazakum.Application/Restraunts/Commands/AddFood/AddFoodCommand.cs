using System;
using MediatR;

namespace Zakazakum.Application.Restraunts.Commands.AddFood
{
	public class AddFoodCommand : IRequest
	{
		public Guid RestaurantId { get; set; }

		public AddFoodVm Food { get; set; }
	}
}
