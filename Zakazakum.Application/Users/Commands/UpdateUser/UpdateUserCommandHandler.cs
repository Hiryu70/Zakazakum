using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Users.Commands.UpdateUser
{
	public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
	{
		private readonly IZakazakumContext _context;

		public UpdateUserCommandHandler(IZakazakumContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
		{
			var user = _context.Users.FirstOrDefault(u => u.Id == request.Id);
			user.Name = request.Name;
			user.PhoneNumber = request.PhoneNumber;
			user.BankName = request.BankName;

			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
