using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.Application.Orders.Queries.GetOrder
{
	public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, GetOrderVm>
	{
		private readonly IZakazakumContext _context;
		private readonly IMapper _mapper;

		public GetOrderQueryHandler(IZakazakumContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<GetOrderVm> Handle(GetOrderQuery request, CancellationToken cancellationToken)
		{
			var order = await _context.Orders
				.Include(o => o.Restaurant)
				.Include(o => o.Owner)
				.FirstOrDefaultAsync(o => o.Id == request.OrderId);

			var vm = _mapper.Map<GetOrderVm>(order);

			foreach (var userOrder in order.UserOrders)
			{
				var userReceipt = new UserReceiptVm()
				{
					Total = userOrder.FoodOrders.Select(fo => fo.Count * fo.Food.Cost).Sum(),
					Name = userOrder.User.Name
				};

				vm.UserReceipts.Add(userReceipt);
			}

			return vm;
		}
	}
}
