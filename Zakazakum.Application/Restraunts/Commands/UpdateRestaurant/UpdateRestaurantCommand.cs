using MediatR;
using System;

namespace Zakazakum.Application.Restraunts.Commands.UpdateRestaurant
{
	public class UpdateRestaurantCommand : IRequest
	{
		public Guid Id { get; set; }

		public string Title { get; set; }
	}
}
