using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Restraunts.Commands.DeleteFood
{
	public class DeleteFoodCommandValidator : AbstractValidator<DeleteFoodCommand>
	{
		private readonly IZakazakumContext _context;

		public DeleteFoodCommandValidator(IZakazakumContext context)
		{
			_context = context;
			RuleFor(x => x.RestaurantId).MustAsync(RestaurantExists)
				.WithMessage("Ресторан не найден.");
			RuleFor(x => x.Food).MustAsync(FoodExists)
				.WithMessage("Еда не найдена");
		}

		private async Task<bool> RestaurantExists(DeleteFoodCommand command, Guid id, CancellationToken cancellationToken)
		{
			var restaurant = await _context.Restaurants.FirstOrDefaultAsync(r => r.Id == id);

			if (restaurant != null)
			{
				return true;
			}

			return false;
		}

		private async Task<bool> FoodExists(DeleteFoodCommand command, DeleteFoodVm food, CancellationToken cancellationToken)
		{
			var restaurant = await _context.Restaurants
				.Include(r => r.Foods)
				.FirstOrDefaultAsync(r => r.Id == command.RestaurantId);

			var existsFood = restaurant.Foods.FirstOrDefault(f => f.Id == food.Id);

			if (existsFood != null)
			{
				return true;
			}

			return false;
		}
	}
}
