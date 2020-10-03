using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Orders.Commands.SetUserPaidStatus
{
	public class SetUserPaidStatusCommandHandler : IRequestHandler<SetUserPaidStatusCommand>
	{
		private readonly IZakazakumContext _context;

		public SetUserPaidStatusCommandHandler(IZakazakumContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(SetUserPaidStatusCommand request, CancellationToken cancellationToken)
		{
			var order = await _context.Orders
				.Include(o => o.UserOrders).ThenInclude(uo => uo.User)
				.FirstAsync(r => r.Id == request.OrderId);

			var userOrder = order.UserOrders.FirstOrDefault(uo => uo.User.Id == request.UserId);

			userOrder.IsOrderPaid = request.IsPaid;

			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
