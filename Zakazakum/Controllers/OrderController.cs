using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zakazakum.Application.Orders.Commands.AddFoodOrder;
using Zakazakum.Application.Orders.Commands.CreateOrder;
using Zakazakum.Application.Orders.Commands.DeleteFoodOrder;
using Zakazakum.Application.Orders.Commands.SetOrderStatus;
using Zakazakum.Application.Orders.Commands.SetUserPaidStatus;
using Zakazakum.Application.Orders.Commands.UpdateDeliveryCost;
using Zakazakum.Application.Orders.Commands.UpdateFoodOrder;
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
		public async Task<IActionResult> GetAll([FromQuery]GetOrdersListQuery command)
		{
			var vm = await Mediator.Send(command);

			return Ok(vm);
		}

		/// <summary>
		/// Получить заказ по идентификатору
		/// </summary>
		/// <returns>Данные по заказу</returns>
		[HttpGet("{orderId}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetOrderVm))]
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
		[HttpPost("{orderId}/food-order")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddFoodOrder([FromBody]AddFoodOrderVm foodOrder, [FromRoute] int orderId)
		{
			var command = new AddFoodOrderCommand
			{
				FoodOrder = foodOrder,
				OrderId = orderId
			};
			await Mediator.Send(command);

			return NoContent();
		}

		/// <summary>
		/// Редактировать еду в заказе
		/// </summary>
		/// <param name="foodOrder">Заказ еды</param>
		/// <param name="orderId">Идентификатор заказа</param>
		[HttpPut("{orderId}/food-order")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddFoodOrder([FromBody] UpdateFoodOrderVm foodOrder, [FromRoute] int orderId)
		{
			var command = new UpdateFoodOrderCommand
			{
				FoodOrder = foodOrder,
				OrderId = orderId
			};
			await Mediator.Send(command);

			return NoContent();
		}

		/// <summary>
		/// Удалить еду в заказе
		/// </summary>
		/// <param name="foodOrder">Заказ еды</param>
		/// <param name="orderId">Идентификатор заказа</param>
		[HttpDelete("{orderId}/food-order")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddFoodOrder([FromBody] DeleteFoodOrderVm foodOrder, [FromRoute] int orderId)
		{
			var command = new DeleteFoodOrderCommand
			{
				FoodOrder = foodOrder,
				OrderId = orderId
			};
			await Mediator.Send(command);

			return NoContent();
		}

		/// <summary>
		/// Установить статус оплаты заказа пользователем
		/// </summary>
		/// <param name="userPaidStatus">Статус оплаты заказа пользователем</param>
		/// <param name="orderId">Идентификатор заказа</param>
		[HttpPost("{orderId}/set-user-paid")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> SetUserPaidStatus([FromBody] UserPaidStatusVm userPaidStatus, [FromRoute] int orderId)
		{
			var command = new SetUserPaidStatusCommand
			{
				IsPaid = userPaidStatus.IsPaid,
				UserId = userPaidStatus.UserId,
				OrderId = orderId
			};
			await Mediator.Send(command);

			return NoContent();
		}

		/// <summary>
		/// Установить статус заказа
		/// </summary>
		/// <param name="orderStatus">Статус заказа</param>
		/// <param name="orderId">Идентификатор заказа</param>
		[HttpPost("{orderId}/set-order-status")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> SetOrderStatus([FromBody] SetOrderStatusVm orderStatus, [FromRoute] int orderId)
		{
			var command = new SetOrderStatusCommand
			{
				OrderStatus = orderStatus.OrderStatus,
				OrderId = orderId
			};

			await Mediator.Send(command);

			return NoContent();
		}
	}
}
