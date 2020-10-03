using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Users.Queries.IsPhoneNumberIsTaken
{
	public class IsPhoneNumberIsTakenQueryHandler : IRequestHandler<IsPhoneNumberIsTakenQuery, bool>
	{
		private readonly IZakazakumContext _context;

		public IsPhoneNumberIsTakenQueryHandler(IZakazakumContext context)
		{
			_context = context;
		}

		public async Task<bool> Handle(IsPhoneNumberIsTakenQuery request, CancellationToken cancellationToken)
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