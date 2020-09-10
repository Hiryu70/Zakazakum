using System.Collections.Generic;

namespace Zakazakum.Application.Restraunts.Queries.GetFoods
{
	public class FoodsListVm
	{
		public string Title { get; set; }
		public IList<GetFoodVm> Foods { get; set; }
	}
}
