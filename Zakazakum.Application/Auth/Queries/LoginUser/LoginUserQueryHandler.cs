using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Auth.Queries.LoginUser
{
	public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginUserVm>
	{
		private readonly IIdentityService _identityService;

		public LoginUserQueryHandler(IIdentityService identityService)
		{
			_identityService = identityService;
		}

		public async Task<LoginUserVm> Handle(LoginUserQuery request, CancellationToken cancellationToken)
		{
			var token = await _identityService.LoginUserAsync(request);

			var loginUserVm = new LoginUserVm
			{
				Token = token
			};

			return loginUserVm;
		}
	}
}
