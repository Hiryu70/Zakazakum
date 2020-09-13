using System;
using MediatR;

namespace Zakazakum.Application.Users.Commands.CreateUser
{
	public class CreateUserCommand : IRequest
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string PhoneNumber { get; set; }

		public string BankName { get; set; }
	}
}
