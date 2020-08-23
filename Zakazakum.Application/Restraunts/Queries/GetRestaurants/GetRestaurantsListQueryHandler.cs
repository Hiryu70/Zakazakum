using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Restraunts.Queries.GetRestaurants
{
	public class GetRestaurantsListQueryHandler : IRequestHandler<GetRestaurantsListQuery, RestaurantsListVm>
	{
		private readonly IZakazakumContext _context;
		private readonly IMapper _mapper;

		public GetRestaurantsListQueryHandler(IZakazakumContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<RestaurantsListVm> Handle(GetRestaurantsListQuery request, CancellationToken cancellationToken)
		{
			List<RestaurantVm> restaurants = await _context.Restaurants
				.ProjectTo<RestaurantVm>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);

			var vm = new RestaurantsListVm
			{
				Restaurants = restaurants
			};

			return vm;
		}
	}
} 