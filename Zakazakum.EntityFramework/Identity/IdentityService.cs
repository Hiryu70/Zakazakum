using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Zakazakum.Application.Auth.Commands.RegisterUser;
using Zakazakum.Application.Auth.Queries.LoginUser;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.EntityFramework.Identity
{
	class IdentityService : IIdentityService
	{
		private UserManager<ApplicationUser> _userManager;
		private readonly IConfiguration _configuration;

		public IdentityService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
		{
			_userManager = userManager;
			_configuration = configuration;
		}

		public async Task CreateUserAsync(RegisterUserCommand registerUserCommand)
		{
			var user = new ApplicationUser()
			{
				UserName = registerUserCommand.PhoneNumber,
				PhoneNumber = registerUserCommand.PhoneNumber,
				Name = registerUserCommand.Name,
				BankName = registerUserCommand.BankName
			};

			var result = await _userManager.CreateAsync(user, registerUserCommand.Password);
		}

		public async Task<string> LoginUserAsync(LoginUserQuery loginUserCommand)
		{
			var user = await _userManager.FindByNameAsync(loginUserCommand.PhoneNumber);
			if (user != null && await _userManager.CheckPasswordAsync(user, loginUserCommand.Password))
			{
				var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT_Secret"));

				var tokenDescriptor = new SecurityTokenDescriptor
				{
					Subject = new ClaimsIdentity(new Claim[]
					{
						new Claim("UserId", user.Id.ToString())
					}),
					Expires = DateTime.UtcNow.AddDays(1),
					SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
				};

				var tokenHander = new JwtSecurityTokenHandler();
				var securityToken = tokenHander.CreateToken(tokenDescriptor);
				var token = tokenHander.WriteToken(securityToken);
				return token;
			}
			else
			{
				return null;
			}
		}
	}
}
