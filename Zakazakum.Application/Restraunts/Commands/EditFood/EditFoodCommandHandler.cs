using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Restraunts.Commands.EditFood
{
	public class EditFoodCommandHandler : IRequestHandler<EditFoodCommand>
	{
		private readonly IZakazakumContext _context;
		private readonly IMapper _mapper;

		public EditFoodCommandHandler(IZakazakumContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(EditFoodCommand request, CancellationToken cancellationToken)
		{
			var restaurant = await _context.Restaurants
				.Include(r => r.Foods)
				.FirstAsync(r => r.Id == request.RestaurantId);

			var food = restaurant.Foods.FirstOrDefault(f => f.Id == request.Food.Id);
			food.Title = request.Food.Title;
			food.Description = request.Food.Description;
			food.Cost = request.Food.Cost;

			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
