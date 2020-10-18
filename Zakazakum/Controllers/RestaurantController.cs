using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zakazakum.Application.Restraunts.Commands.AddFood;
using Zakazakum.Application.Restraunts.Commands.CreateRestaurant;
using Zakazakum.Application.Restraunts.Commands.DeleteFood;
using Zakazakum.Application.Restraunts.Commands.EditFood;
using Zakazakum.Application.Restraunts.Commands.UpdateRestaurant;
using Zakazakum.Application.Restraunts.Queries.GetFoods;
using Zakazakum.Application.Restraunts.Queries.GetRestaurants;
using Zakazakum.Application.Users.Queries.IsPhoneNumberIsTaken;

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
		/// Редактировать ресторан
		/// </summary>
		/// <param name="command">Новые параметры ресторана</param>
		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Update([FromBody] UpdateRestaurantCommand command)
		{
			await Mediator.Send(command);

			return NoContent();
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
		/// <param name="food">Еда</param>
		[HttpPost("{restaurantId}/food")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> Create([FromRoute]Guid restaurantId, [FromBody] AddFoodVm food)
		{
			await Mediator.Send(new AddFoodCommand { Food = food, RestaurantId = restaurantId });

			return NoContent();
		}

		/// <summary>
		/// Редактировать еду в ресторане
		/// </summary>
		/// <param name="restaurantId">Идентификатор ресторана</param>
		/// <param name="food">Еда</param>
		[HttpPut("{restaurantId}/food")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> Update([FromRoute] Guid restaurantId, [FromBody] EditFoodVm food)
		{
			await Mediator.Send(new EditFoodCommand { Food = food, RestaurantId = restaurantId });

			return NoContent();
		}

		/// <summary>
		/// Удалить еду в ресторане
		/// </summary>
		/// <param name="restaurantId">Идентификатор ресторана</param>
		/// <param name="food">Еда</param>
		[HttpDelete("{restaurantId}/food")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> Delete([FromRoute] Guid restaurantId, [FromBody] DeleteFoodVm food)
		{
			await Mediator.Send(new DeleteFoodCommand { Food = food, RestaurantId = restaurantId });

			return NoContent();
		}

		/// <summary>
		/// Блюдо с данным названием уже существует в ресторане
		/// </summary>
		/// <param name="command">Параметры блюда</param>
		[HttpPost("is-food-title-taken")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<bool>> IsFoodTitleTaken([FromBody] IsFoodTitleTakenQuery command)
		{
			var vm = await Mediator.Send(command);

			return Ok(vm);
		}
	}
}
