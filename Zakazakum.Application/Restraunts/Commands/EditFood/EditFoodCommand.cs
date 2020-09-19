using System;
using MediatR;

namespace Zakazakum.Application.Restraunts.Commands.EditFood
{
	public class EditFoodCommand : IRequest
	{
		public Guid RestaurantId { get; set; }

		public EditFoodVm Food { get; set; }
	}
}
