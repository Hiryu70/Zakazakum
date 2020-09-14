using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Zakazakum.Application.Common.Interfaces;
using Zakazakum.Domain.Entities;

namespace Zakazakum.Application.Users.Commands.CreateUser
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
	{
		private readonly IZakazakumContext _context;

		public CreateUserCommandHandler(IZakazakumContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			var entity = new User
			{
				Name = request.Name,
				PhoneNumber = request.PhoneNumber,
				BankName = request.BankName
			};

			_context.Users.Add(entity);

			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
