using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Restraunts.Commands.AddFood
{
	public class AddFoodCommandValidator : AbstractValidator<AddFoodCommand>
	{
		private readonly IZakazakumContext _context;

		public AddFoodCommandValidator(IZakazakumContext context)
		{
			_context = context;
			RuleFor(x => x.RestaurantId).MustAsync(RestaurantExists)
				.WithMessage("Ресторан не найден.");
			RuleFor(x => x.Food.Cost).GreaterThanOrEqualTo(0);
			RuleFor(x => x.Food.Title).NotEmpty();
		}

		private async Task<bool> RestaurantExists(AddFoodCommand command, Guid id, CancellationToken cancellationToken)
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
