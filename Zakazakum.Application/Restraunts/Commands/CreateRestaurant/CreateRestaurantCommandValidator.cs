using FluentValidation;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Restraunts.Commands.CreateRestaurant
{
	public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
	{
		private readonly IZakazakumContext _context;

		public CreateRestaurantCommandValidator(IZakazakumContext context)
		{
			_context = context;
			RuleFor(x => x.Title).MaximumLength(100);
			RuleFor(x => x.Title).NotEmpty();
		}
	}
}
