using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;
using Zakazakum.Domain.Entities;

namespace Zakazakum.Application.Orders.Commands.AddFoodOrder
{
	public class AddFoodCommandHandler : IRequestHandler<AddFoodCommand>
	{
		private readonly IZakazakumContext _context;
		private readonly IMapper _mapper;

		public AddFoodCommandHandler(IZakazakumContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(AddFoodCommand request, CancellationToken cancellationToken)
		{
			var restaurant = await _context.Restaurants
				.Include(r => r.Foods)
				.FirstAsync(r => r.Id == request.RestaurantId);

			var food = _mapper.Map<Food>(request.Food);

			restaurant.Foods.Add(food);

			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
