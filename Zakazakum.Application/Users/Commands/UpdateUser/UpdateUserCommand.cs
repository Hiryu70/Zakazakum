using System;
using MediatR;

namespace Zakazakum.Application.Users.Commands.UpdateUser
{
	public class UpdateUserCommand : IRequest
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string PhoneNumber { get; set; }

		public string BankName { get; set; }
	}
}
