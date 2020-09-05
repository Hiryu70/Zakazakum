using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Orders.Queries.GetOrder
{
	public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderVm>
	{
		private readonly IZakazakumContext _context;
		private readonly IMapper _mapper;

		public GetOrderQueryHandler(IZakazakumContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<OrderVm> Handle(GetOrderQuery request, CancellationToken cancellationToken)
		{
			var orders = await _context.Orders
				.Include(o => o.Restaurant)
				.Include(o => o.Owner)
				.ToListAsync(cancellationToken);
			var order = orders.FirstOrDefault(o => o.Id == request.OrderId);

			var vm = _mapper.Map<OrderVm>(order);

			return vm;
		}
	}
}
