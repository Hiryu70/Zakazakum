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
		/// Get all users
		/// </summary>
		/// <returns>List of users</returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<UsersListVm>> GetAll()
		{
			var vm = await Mediator.Send(new GetUsersListQuery());

			return Ok(vm);
		}

		/// <summary>
		/// Create new user
		/// </summary>
		/// <param name="command">New user details</param>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<IActionResult> Create([FromBody]CreateUserCommand command)
		{
			await Mediator.Send(command);

			return NoContent();
		}
	}
}
