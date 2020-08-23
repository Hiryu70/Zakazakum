using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zakazakum.Application.Orders.Commands.CreateOrder;
using Zakazakum.Application.Orders.Commands.UpdateDeliveryCost;

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

		/// <summary>
		/// Update delivery cost
		/// </summary>
		/// <param name="deliveryCost">New delivery cost</param>
		/// <param name="orderId">Order ID</param>
		[HttpPost("{orderId}/update-delivery-cost")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> UpdateDeliveryCost([FromBody]DeliveryCostVm deliveryCost, [FromRoute] int orderId)
		{
			var command = new UpdateDeliveryCostCommand
			{
				DeliveryCost = deliveryCost.DeliveryCost,
				OrderId = orderId
			};
			await Mediator.Send(command);

			return NoContent();
		}
	}
}
