using MediatR;

namespace Zakazakum.Application.Meals.Queries.GetMealsList
{
	public class GetMealsListQuery : IRequest<MealListVm>
	{
	}
}
