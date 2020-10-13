using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Restraunts.Commands.UpdateRestaurant
{
	public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand>
	{
		private readonly IZakazakumContext _context;

		public UpdateRestaurantCommandHandler(IZakazakumContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
		{
			var restaurant = _context.Restaurants.FirstOrDefault(u => u.Id == request.Id);
			restaurant.Title = request.Title;

			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
