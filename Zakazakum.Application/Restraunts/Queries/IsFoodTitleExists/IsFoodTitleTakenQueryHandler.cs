using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Users.Queries.IsPhoneNumberIsTaken
{
	public class IsFoodTitleTakenQueryHandler : IRequestHandler<IsFoodTitleTakenQuery, bool>
	{
		private readonly IZakazakumContext _context;

		public IsFoodTitleTakenQueryHandler(IZakazakumContext context)
		{
			_context = context;
		}

		public async Task<bool> Handle(IsFoodTitleTakenQuery request, CancellationToken cancellationToken)
		{
			var restaurant = await _context.Restaurants
				.Include(r => r.Foods)
				.FirstOrDefaultAsync(r => r.Id == request.RestaurantId);

			var food = restaurant.Foods.FirstOrDefault(f => f.Title == request.Title);

			if (food == null)
			{
				return false;
			}

			if (food.Id == request.FoodId)
			{
				return false;
			}

			return true;
		}
	}
}