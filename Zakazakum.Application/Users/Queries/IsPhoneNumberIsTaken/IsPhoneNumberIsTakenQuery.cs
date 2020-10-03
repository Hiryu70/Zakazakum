using MediatR;
using System;

namespace Zakazakum.Application.Users.Queries.IsPhoneNumberIsTaken
{
	public class IsPhoneNumberIsTakenQuery : IRequest<bool>
	{
		public string PhoneNumber { get; set; }

		public Guid UserId { get; set; }
	}
}
