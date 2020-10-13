using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Users.Commands.UpdateUser
{
	public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
	{
		private readonly IZakazakumContext _context;

		public UpdateUserCommandValidator(IZakazakumContext context)
		{
			_context = context;
			RuleFor(x => x.Name).MaximumLength(100);
			RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.PhoneNumber).MustAsync(UniquePhoneNumber)
				.When(x => !string.IsNullOrEmpty(x.PhoneNumber))
				.WithMessage("Номер телефона должен быть уникален.");
			RuleFor(x => x.PhoneNumber).Length(11)
				.When(x => !string.IsNullOrEmpty(x.PhoneNumber));
			RuleFor(x => x.Id).MustAsync(UserExists)
				.WithMessage("Пользователь не найден.");
		}

		private async Task<bool> UniquePhoneNumber(UpdateUserCommand command, string phoneNumber, CancellationToken cancellationToken)
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

		private async Task<bool> UserExists(UpdateUserCommand command, Guid id, CancellationToken cancellationToken)
		{
			var user = await _context.Users.FirstOrDefaultAsync(r => r.Id == id);

			if (user != null)
			{
				return true;
			}

			return false;
		}
	}
}
