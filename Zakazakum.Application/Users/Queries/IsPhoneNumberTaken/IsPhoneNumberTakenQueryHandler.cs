using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Users.Queries.IsPhoneNumberTaken
{
	public class IsPhoneNumberTakenQueryHandler : IRequestHandler<IsPhoneNumberTakenQuery, bool>
	{
		private readonly IZakazakumContext _context;

		public IsPhoneNumberTakenQueryHandler(IZakazakumContext context)
		{
			_context = context;
		}

		public async Task<bool> Handle(IsPhoneNumberTakenQuery request, CancellationToken cancellationToken)
		{
			var user = await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber);

			if (user == null)
			{
				return false;
			}

			if (user.Id == request.UserId)
			{
				return false;
			}

			return true;
		}
	}
}