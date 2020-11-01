using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zakazakum.Application.Auth.Commands.RegisterUser;

namespace Zakazakum.API.Controllers
{
	/// <summary>
	/// Auth controller
	/// </summary>
	[ApiController]
	public class AuthController : BaseController
	{
		/// <summary>
		/// Зарегестрировать нового пользователя
		/// </summary>
		/// <param name="command">Параметры нового пользователя</param>
		[HttpPost]
		[Route("register")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<object> PostApplicationUser(RegisterUserCommand command)
		{
			var id = await Mediator.Send(command);
			
			return Ok(id);
		}
	}
}
