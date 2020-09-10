using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zakazakum.Application.Orders.Commands.AddFoodOrder;
using Zakazakum.Application.Restraunts.Commands.AddFood;
using Zakazakum.Application.Restraunts.Commands.CreateRestaurant;
using Zakazakum.Application.Restraunts.Queries.GetFoods;
using Zakazakum.Application.Restraunts.Queries.GetRestaurants;

namespace Zakazakum.API.Controllers
{
	/// <summary>
	/// Restaurants controller
	/// </summary>
	public class RestaurantController : BaseController
	{
		/// <summary>
		/// Получить все рестораны
		/// </summary>
		/// <returns>Список ресторанов</returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<RestaurantsListVm>> GetAll()
		{
			var vm = await Mediator.Send(new GetRestaurantsListQuery());

			return Ok(vm);
		}

		/// <summary>
		/// Создать новый ресторан
		/// </summary>
		/// <returns>Идентификатор нового ресторана</returns>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<RestaurantsListVm>> Create([FromBody] CreateRestaurantCommand command)
		{
			var vm = await Mediator.Send(command);

			return Ok(vm);
		}

		/// <summary>
		/// Получить всю еду в ресторане
		/// </summary>
		/// <param name="restaurantId">Идентификатор ресторана</param>
		/// <returns>Список доступной еды в ресторане</returns>
		[HttpGet("{restaurantId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<FoodsListVm>> GetFoods(Guid restaurantId)
		{
			var vm = await Mediator.Send(new GetFoodsListQuery { RestaurantId = restaurantId });

			return Ok(vm);
		}

		/// <summary>
		/// Создать новую еду в ресторане
		/// </summary>
		/// <param name="restaurantId">Идентификатор ресторана</param>
		[HttpPost("{restaurantId}/food")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> Create([FromRoute]Guid restaurantId, [FromBody] AddFoodVm food)
		{
			await Mediator.Send(new AddFoodCommand { Food = food, RestaurantId = restaurantId });

			return NoContent();
		}
	}
}
