using FluentValidation;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Auth.Queries.LoginUser
{
	public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
	{
		private readonly IIdentityService _identityService;

		public LoginUserQueryValidator(IIdentityService identityService)
		{
			_identityService = identityService;
		}
	}
}
