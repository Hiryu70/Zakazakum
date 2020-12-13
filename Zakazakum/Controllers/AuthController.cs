using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zakazakum.Application.Auth.Commands.RegisterUser;
using Zakazakum.Application.Auth.Queries.LoginUser;

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
		public async Task<object> Register(RegisterUserCommand command)
		{
			var id = await Mediator.Send(command);
			
			return Ok(id);
		}

		/// <summary>
		/// Выполнить вход пользователя
		/// </summary>
		/// <param name="command">Параметры пользователя</param>
		[HttpPost]
		[Route("login")]
		public async Task<ActionResult<LoginUserVm>> Login(LoginUserQuery command)
		{
			var logiUserVm = await Mediator.Send(command);

			if (logiUserVm.Token != null)
				return Ok(logiUserVm);
			else
				return BadRequest(new { message = "Номер телефона или пароль неверен." });
		}
	}
}
