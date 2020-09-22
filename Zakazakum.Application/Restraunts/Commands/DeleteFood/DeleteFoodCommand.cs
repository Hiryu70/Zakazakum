using System;
using MediatR;

namespace Zakazakum.Application.Restraunts.Commands.DeleteFood
{
	public class DeleteFoodCommand : IRequest
	{
		public Guid RestaurantId { get; set; }

		public DeleteFoodVm Food { get; set; }
	}
}
