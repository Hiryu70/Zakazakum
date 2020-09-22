using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;
using Zakazakum.Domain.Entities;

namespace Zakazakum.Application.Restraunts.Commands.DeleteFood
{
	public class DeleteFoodCommandHandler : IRequestHandler<DeleteFoodCommand>
	{
		private readonly IZakazakumContext _context;
		private readonly IMapper _mapper;

		public DeleteFoodCommandHandler(IZakazakumContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(DeleteFoodCommand request, CancellationToken cancellationToken)
		{
			var restaurant = await _context.Restaurants
				.Include(r => r.Foods)
				.FirstAsync(r => r.Id == request.RestaurantId);

			var food = restaurant.Foods.FirstOrDefault(f => f.Id == request.Food.Id);

			restaurant.Foods.Remove(food);

			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
