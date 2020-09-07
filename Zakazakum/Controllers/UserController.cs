using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zakazakum.Application.Users.Commands.CreateUser;
using Zakazakum.Application.Users.Queries.GetUsers;

namespace Zakazakum.API.Controllers
{
	/// <summary>
	/// Users controller
	/// </summary>
	public class UserController : BaseController
	{
		/// <summary>
		/// Получить всех пользователей
		/// </summary>
		/// <returns>Список пользователей</returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<UsersListVm>> GetAll()
		{
			var vm = await Mediator.Send(new GetUsersListQuery());

			return Ok(vm);
		}

		/// <summary>
		/// Создать нового пользователя
		/// </summary>
		/// <param name="command">Параметры нового пользователя</param>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Create([FromBody]CreateUserCommand command)
		{
			await Mediator.Send(command);

			return NoContent();
		}
	}
}
