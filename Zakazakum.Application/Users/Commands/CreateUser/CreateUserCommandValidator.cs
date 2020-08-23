using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Users.Commands.CreateUser
{
	public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
	{
		private readonly IZakazakumContext _context;

		public CreateUserCommandValidator(IZakazakumContext context)
		{
			_context = context;
			RuleFor(x => x.Name).MaximumLength(100);
			RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.PhoneNumber).MustAsync(UniquePhoneNumber)
				.When(x => !string.IsNullOrEmpty(x.PhoneNumber))
				.WithMessage("Номер телефона должен быть уникален");
			RuleFor(x => x.PhoneNumber).Length(11)
				.When(x => !string.IsNullOrEmpty(x.PhoneNumber));
		}

		private async Task<bool> UniquePhoneNumber(CreateUserCommand command, string phoneNumber, CancellationToken cancellationToken)
		{
			var user = await _context.Users.FirstOrDefaultAsync(s => s.PhoneNumber == phoneNumber, cancellationToken);
			if (user == null)
			{
				return true;
			}

			if (user.Id == command.Id)
			{
				return true;
			}

			return false;
		}
	}
}
