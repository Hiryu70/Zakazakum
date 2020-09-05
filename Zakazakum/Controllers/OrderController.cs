using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zakazakum.Application.Orders.Commands.AddFoodOrder;
using Zakazakum.Application.Orders.Commands.CreateOrder;
using Zakazakum.Application.Orders.Commands.UpdateDeliveryCost;
using Zakazakum.Application.Orders.Queries.GetOrder;
using Zakazakum.Application.Orders.Queries.GetOrders;

namespace Zakazakum.API.Controllers
{
	/// <summary>
	/// Orders controller
	/// </summary>
	public class OrderController : BaseController
	{
		/// <summary>
		/// Get all orders
		/// </summary>
		/// <returns>List of orders</returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> GetAll()
		{
			var vm = await Mediator.Send(new GetOrdersListQuery());

			return Ok(vm);
		}

		/// <summary>
		/// Get order by Id
		/// </summary>
		/// <returns>Get order data</returns>
		[HttpGet("{orderId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> GetById([FromRoute]int orderId)
		{
			var vm = await Mediator.Send(new GetOrderQuery() { OrderId = orderId });

			return Ok(vm);
		}

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

		/// <summary>
		/// Add food order
		/// </summary>
		/// <param name="foodOrders">Food orders</param>
		/// <param name="orderId">Order ID</param>
		[HttpPost("{orderId}/add-food-order")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddFoodOrder([FromBody]List<FoodOrderVm> foodOrders, [FromRoute] int orderId)
		{
			var command = new AddFoodOrderCommand
			{
				FoordOrders = foodOrders,
				OrderId = orderId
			};
			await Mediator.Send(command);

			return NoContent();
		}
	}
}
