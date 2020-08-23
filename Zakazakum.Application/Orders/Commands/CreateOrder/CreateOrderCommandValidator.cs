using System;
using System.Linq;
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
				.WithMessage("Не найден ресторан с указанным идентификатором");
		}

		private async Task<bool> RestaurantExists(CreateOrderCommand command, Guid restaurantId, CancellationToken cancellationToken)
		{
			var restaurants = await _context.Restaurants.ToListAsync(cancellationToken);
			var restaurant = restaurants.First(r => r.Id == restaurantId);

			if (restaurant != null)
			{
				return true;
			}

			return false;
		}
	}
}
