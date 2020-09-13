using System;
using System.Collections.Generic;
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
				.Include(o => o.UserOrders)
				.ThenInclude(uo => uo.FoodOrders)
				.ThenInclude(fo => fo.Food)
				.FirstOrDefaultAsync(o => o.Id == request.OrderId);

			var vm = _mapper.Map<GetOrderVm>(order);

			vm.DeliveryCostPerUser = (float)Math.Round(order.DeliveryCost / order.UserOrders.Count, 0);

			vm.UserReceipts = new List<UserReceiptVm>();
			foreach (var userOrder in order.UserOrders)
			{
				var userReceipt = new UserReceiptVm()
				{
					Total = userOrder.FoodOrders.Select(fo => fo.Count * fo.Food.Cost).Sum() + vm.DeliveryCostPerUser,
					Name = userOrder.User.Name
				};

				vm.UserReceipts.Add(userReceipt);
			}

			vm.FoodReceipts = new List<FoodReceiptVm>();
			var foodOrders = order.UserOrders.SelectMany(uo => uo.FoodOrders);
			foreach (var foodOrder in foodOrders)
			{
				var foodReceipt = vm.FoodReceipts.FirstOrDefault(fr => fr.Title == foodOrder.Food.Title && fr.Comment == foodOrder.Comment);
				if (foodReceipt == null)
				{
					var newFoodRecept = new FoodReceiptVm
					{
						Title = foodOrder.Food.Title,
						Comment = foodOrder.Comment,
						Count = foodOrder.Count
					};
					vm.FoodReceipts.Add(newFoodRecept);
				}
				else
				{
					foodReceipt.Count += foodOrder.Count;
				}
			}

			return vm;
		}
	}
}
