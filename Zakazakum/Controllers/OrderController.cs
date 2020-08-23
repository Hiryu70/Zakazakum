using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zakazakum.Application.Orders.Commands.CreateOrder;

namespace Zakazakum.API.Controllers
{
	/// <summary>
	/// Orders controller
	/// </summary>
	public class OrderController : BaseController
	{
		/// <summary>
		/// Create new order
		/// </summary>
		/// <param name="command">New order ID</param>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<CreateOrderVm>> Create([FromBody]CreateOrderCommand command)
		{
			var id = await Mediator.Send(command);

			return Ok(id);
		}
	}
}
