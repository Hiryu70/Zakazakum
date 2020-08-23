using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
		/// Get all restaurants
		/// </summary>
		/// <returns>List of restaurants</returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<RestaurantsListVm>> GetAll()
		{
			var vm = await Mediator.Send(new GetRestaurantsListQuery());

			return Ok(vm);
		}

		/// <summary>
		/// Get all foods in restaurant
		/// </summary>
		/// <param name="restaurantId">Restaurant ID</param>
		/// <returns></returns>
		[HttpGet("{restaurantId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<FoodsListVm>> GetFoods(Guid restaurantId)
		{
			var vm = await Mediator.Send(new GetFoodsListQuery { RestaurantId = restaurantId });

			return Ok(vm);
		}
	}
}
