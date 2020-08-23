using System;
using MediatR;

namespace Zakazakum.Application.Restraunts.Queries.GetFoods
{
	public class GetFoodsListQuery : IRequest<FoodsListVm>
	{
		public Guid RestaurantId { get; set; }
	}
}
