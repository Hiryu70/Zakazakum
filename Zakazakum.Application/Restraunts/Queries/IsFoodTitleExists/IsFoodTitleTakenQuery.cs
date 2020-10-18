using MediatR;
using System;

namespace Zakazakum.Application.Users.Queries.IsPhoneNumberIsTaken
{
	public class IsFoodTitleTakenQuery : IRequest<bool>
	{
		public string Title { get; set; }

		public Guid RestaurantId { get; set; }

		public Guid FoodId { get; set; }
	}
}
