using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Auth.Commands.RegisterUser
{
	public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
	{
		private readonly IIdentityService _identityService;

		public RegisterUserCommandHandler(IIdentityService identityService)
		{
			_identityService = identityService;
		}

		public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
		{
			await _identityService.CreateUserAsync(request);

			return Unit.Value;
		}
	}
}
