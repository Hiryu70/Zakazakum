using MediatR;
using System;

namespace Zakazakum.Application.Users.Queries.IsPhoneNumberTaken
{
	public class IsPhoneNumberTakenQuery : IRequest<bool>
	{
		public string PhoneNumber { get; set; }

		public Guid UserId { get; set; }
	}
}
