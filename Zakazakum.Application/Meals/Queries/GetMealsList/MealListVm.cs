using System.Collections.Generic;

namespace Zakazakum.Application.Meals.Queries.GetMealsList
{
	public class MealListVm
	{
		public int TotalCount { get; set; }
		public IList<MealVm> Meals { get; set; }
	}
}
