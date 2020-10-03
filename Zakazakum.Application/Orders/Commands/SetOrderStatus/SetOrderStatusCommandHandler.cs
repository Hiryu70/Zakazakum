using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Orders.Commands.SetOrderStatus
{
	public class SetOrderStatusCommandHandler : IRequestHandler<SetOrderStatusCommand>
	{
		private readonly IZakazakumContext _context;

		public SetOrderStatusCommandHandler(IZakazakumContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(SetOrderStatusCommand request, CancellationToken cancellationToken)
		{
			var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == request.OrderId);
			order.OrderStatus = request.OrderStatus;

			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
