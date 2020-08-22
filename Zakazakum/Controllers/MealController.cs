using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zakazakum.Application.Meals.Queries.GetMealsList;

namespace Zakazakum.API.Controllers
{
	/// <summary>
	/// Meals controller
	/// </summary>
	public class MealController : BaseController
	{
		/// <summary>
		/// Get all meals
		/// </summary>
		/// <returns>List of meals</returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<MealListVm>> GetAll()
		{
			var vm = await Mediator.Send(new GetMealsListQuery());

			return Ok(vm);
		}
	}
}
