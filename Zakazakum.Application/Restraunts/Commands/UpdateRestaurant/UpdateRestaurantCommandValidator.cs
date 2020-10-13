using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Restraunts.Commands.UpdateRestaurant
{
	public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
	{
		private readonly IZakazakumContext _context;

		public UpdateRestaurantCommandValidator(IZakazakumContext context)
		{
			_context = context;
			RuleFor(x => x.Title).MaximumLength(100);
			RuleFor(x => x.Title).NotEmpty();
			RuleFor(x => x.Id).MustAsync(RestaurantExists)
				.WithMessage("Ресторан не найден.");
		}

		private async Task<bool> RestaurantExists(UpdateRestaurantCommand command, Guid id, CancellationToken cancellationToken)
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
