using MediatR;

namespace Zakazakum.Application.Auth.Queries.LoginUser
{
	public class LoginUserQuery : IRequest<LoginUserVm>
	{
		public string PhoneNumber { get; set; }

		public string Password { get; set; }
	}
}
