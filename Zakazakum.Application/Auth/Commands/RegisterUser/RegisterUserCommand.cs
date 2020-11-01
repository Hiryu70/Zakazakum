using MediatR;

namespace Zakazakum.Application.Auth.Commands.RegisterUser
{
	public class RegisterUserCommand : IRequest
	{
		public string PhoneNumber { get; set; }

		public string Name { get; set; }

		public string BankName { get; set; }

		public string Password { get; set; }
	}
}
