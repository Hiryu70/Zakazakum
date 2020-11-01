using System.Threading.Tasks;
using Zakazakum.Application.Auth.Commands.RegisterUser;

namespace Zakazakum.Application.Common.Interfaces
{
	public interface IIdentityService
	{
		Task CreateUserAsync(RegisterUserCommand registerUserCommand);
	}
}
