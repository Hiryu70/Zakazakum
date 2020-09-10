using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Restraunts.Queries.GetFoods
{
	public class GetFoodsListQueryQueryHandler : IRequestHandler<GetFoodsListQuery, FoodsListVm>
	{
		private readonly IZakazakumContext _context;
		private readonly IMapper _mapper;

		public GetFoodsListQueryQueryHandler(IZakazakumContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<FoodsListVm> Handle(GetFoodsListQuery request, CancellationToken cancellationToken)
		{
			var restaurant = await _context.Restaurants
				.Include(r => r.Foods)
				.FirstAsync(r => r.Id == request.RestaurantId);
			var foods = _mapper.Map<List<GetFoodVm>>(restaurant?.Foods);

			var vm = new FoodsListVm
			{
				Title = restaurant?.Title,
				Foods = foods
			};

			return vm;
		}
	}
} 