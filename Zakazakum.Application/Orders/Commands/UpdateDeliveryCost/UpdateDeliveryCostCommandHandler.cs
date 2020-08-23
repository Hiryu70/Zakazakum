using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Orders.Commands.UpdateDeliveryCost
{
	public class UpdateDeliveryCostCommandHandler : IRequestHandler<UpdateDeliveryCostCommand>
	{
		private readonly IZakazakumContext _context;

		public UpdateDeliveryCostCommandHandler(IZakazakumContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(UpdateDeliveryCostCommand request, CancellationToken cancellationToken)
		{
			var orders = await _context.Orders.ToListAsync(cancellationToken);
			var order = orders.First(r => r.Id == request.OrderId);

			order.DeliveryCost = request.DeliveryCost;

			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
