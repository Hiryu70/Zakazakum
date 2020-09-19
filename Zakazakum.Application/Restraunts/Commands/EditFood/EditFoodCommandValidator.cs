using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Restraunts.Commands.EditFood
{
	public class EditFoodCommandValidator : AbstractValidator<EditFoodCommand>
	{
		private readonly IZakazakumContext _context;

		public EditFoodCommandValidator(IZakazakumContext context)
		{
			_context = context;
			RuleFor(x => x.RestaurantId).MustAsync(RestaurantExists)
				.WithMessage("Ресторан не найден.");
			RuleFor(x => x.Food.Title).NotEmpty();
		}

		private async Task<bool> RestaurantExists(EditFoodCommand command, Guid id, CancellationToken cancellationToken)
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
