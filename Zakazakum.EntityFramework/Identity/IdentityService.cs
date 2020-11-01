using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Zakazakum.Application.Auth.Commands.RegisterUser;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.EntityFramework.Identity
{
	class IdentityService : IIdentityService
	{
		private UserManager<ApplicationUser> _userManager;

		public IdentityService(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task CreateUserAsync(RegisterUserCommand registerUserCommand)
		{
			var applicationUser = new ApplicationUser()
			{
				UserName = registerUserCommand.PhoneNumber,
				PhoneNumber = registerUserCommand.PhoneNumber,
				Name = registerUserCommand.Name,
				BankName = registerUserCommand.BankName
			};

			var result = await _userManager.CreateAsync(applicationUser, registerUserCommand.Password);
		}
	}
}
