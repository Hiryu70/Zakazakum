using FluentValidation;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Auth.Commands.RegisterUser
{
	public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
	{
		private readonly IIdentityService _identityService;

		public RegisterUserCommandValidator(IIdentityService identityService)
		{
			_identityService = identityService;
		}
	}
}
