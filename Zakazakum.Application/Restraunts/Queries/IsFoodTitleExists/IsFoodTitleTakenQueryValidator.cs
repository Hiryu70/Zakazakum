using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;
using Zakazakum.Application.Users.Queries.IsPhoneNumberIsTaken;

namespace Zakazakum.Application.Restraunts.Commands.AddFood
{
	public class IsFoodTitleTakenQueryValidator : AbstractValidator<IsFoodTitleTakenQuery>
	{
		private readonly IZakazakumContext _context;

		public IsFoodTitleTakenQueryValidator(IZakazakumContext context)
		{
			_context = context;
			RuleFor(x => x.RestaurantId).MustAsync(RestaurantExists)
				.WithMessage("Ресторан не найден.");
		}

		private async Task<bool> RestaurantExists(IsFoodTitleTakenQuery command, Guid id, CancellationToken cancellationToken)
		{
			var restaurant = await _context.Restaurants.FirstOrDefaultAsync(r => r.Id == id);

			if (restaurant != null)
			{
				return true;
			}

			return false;
		}
	}
}
