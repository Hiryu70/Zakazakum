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
		/// Получить все заказы
		/// </summary>
		/// <returns>Список заказов</returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrdersListVm))]
		public async Task<IActionResult> GetAll()
		{
			var vm = await Mediator.Send(new GetOrdersListQuery());

			return Ok(vm);
		}

		/// <summary>
		/// Получить заказ по идентификатору
		/// </summary>
		/// <returns>Данные по заказу</returns>
		[HttpGet("{orderId}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetOrdersVm))]
		public async Task<IActionResult> GetById([FromRoute]int orderId)
		{
			var vm = await Mediator.Send(new GetOrderQuery() { OrderId = orderId });

			return Ok(vm);
		}

		/// <summary>
		/// Создать новый заказ
		/// </summary>
		/// <param name="command">Идентификатор нового заказа</param>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateOrderVm))]
		public async Task<ActionResult<CreateOrderVm>> Create([FromBody]CreateOrderCommand command)
		{
			var id = await Mediator.Send(command);

			return Ok(id);
		}

		/// <summary>
		/// Обновить стоимость доставки
		/// </summary>
		/// <param name="deliveryCost">Стоимость доставки</param>
		/// <param name="orderId">Идентификатор заказа</param>
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
		/// Добавить еду в заказ
		/// </summary>
		/// <param name="foodOrder">Заказ еды</param>
		/// <param name="orderId">Идентификатор заказа</param>
		[HttpPost("{orderId}/add-food-order")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddFoodOrder([FromBody]FoodOrderVm foodOrder, [FromRoute] int orderId)
		{
			var command = new AddFoodOrderCommand
			{
				FoodOrder = foodOrder,
				OrderId = orderId
			};
			await Mediator.Send(command);

			return NoContent();
		}
	}
}
