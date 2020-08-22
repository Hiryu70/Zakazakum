using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Meals.Queries.GetMealsList
{
	public class GetMealsListQueryHandler : IRequestHandler<GetMealsListQuery, MealListVm>
	{
		private readonly IZakazakumContext _context;
		private readonly IMapper _mapper;

		public GetMealsListQueryHandler(IZakazakumContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<MealListVm> Handle(GetMealsListQuery request, CancellationToken cancellationToken)
		{
			List<MealVm> meals;
			meals = await _context.Meals
				.ProjectTo<MealVm>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);

			var mealCount = await _context.Meals.CountAsync(cancellationToken);

			var vm = new MealListVm
			{
				Meals = meals,
				TotalCount = mealCount
			};

			return vm;
		}
	}
}