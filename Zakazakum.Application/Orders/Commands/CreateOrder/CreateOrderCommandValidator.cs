using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Orders.Commands.CreateOrder
{
	public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
	{
		private readonly IZakazakumContext _context;

		public CreateOrderCommandValidator(IZakazakumContext context)
		{
			_context = context;
			RuleFor(x => x.RestaurantId).MustAsync(RestaurantExists)
				.WithMessage("Ресторан не найден.");
			RuleFor(x => x.OwnerId).MustAsync(UserExists)
				.WithMessage("Пользователь не найден.");
		}

		private async Task<bool> RestaurantExists(CreateOrderCommand command, Guid restaurantId, CancellationToken cancellationToken)
		{
			var restaurant = await _context.Restaurants.FirstOrDefaultAsync(r => r.Id == restaurantId);

			if (restaurant != null)
			{
				return true;
			}

			return false;
		}

		private async Task<bool> UserExists(CreateOrderCommand command, Guid userId, CancellationToken cancellationToken)
		{
			var user = await _context.Users.FirstOrDefaultAsync(r => r.Id == userId);

			if (user != null)
			{
				return true;
			}

			return false;
		}
	}
}
