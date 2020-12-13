using System.Threading.Tasks;
using Zakazakum.Application.Auth.Commands.RegisterUser;
using Zakazakum.Application.Auth.Queries.LoginUser;

namespace Zakazakum.Application.Common.Interfaces
{
	public interface IIdentityService
	{
		Task CreateUserAsync(RegisterUserCommand registerUserCommand);
		Task<string> LoginUserAsync(LoginUserQuery loginUserCommand);
	}
}
