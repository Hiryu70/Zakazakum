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
			var order = await _context.Orders.FirstAsync(r => r.Id == request.OrderId);

			order.DeliveryCost = request.DeliveryCost;

			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
