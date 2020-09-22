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
				.Include(o => o.UserOrders).ThenInclude(uo => uo.FoodOrders).ThenInclude(fo => fo.Food)
				.Include(o => o.UserOrders).ThenInclude(uo => uo.User)
				.FirstOrDefaultAsync(o => o.Id == request.OrderId);

			var vm = _mapper.Map<GetOrderVm>(order);

			vm.OwnerName = order.Owner.Name;
			vm.OwnerBank = order.Owner.BankName;
			vm.OwnerPhoneNumber = order.Owner.PhoneNumber;
			vm.DeliveryCostPerUser = (float)Math.Round(order.DeliveryCost / order.UserOrders.Count, 0);

			vm.UserReceipts = new List<UserReceiptVm>();
			foreach (var userOrder in order.UserOrders)
			{
				var foodCost = userOrder.FoodOrders.Select(fo => fo.Count * fo.Food.Cost).Sum();
				var deliveryCost = vm.DeliveryCostPerUser;

				var userReceipt = new UserReceiptVm()
				{
					FoodCost = foodCost,
					DeliveryCost = deliveryCost,
					Total = foodCost + deliveryCost,
					Name = userOrder.User.Name,
					IsOrderPaid = userOrder.IsOrderPaid,
					UserId = userOrder.User.Id
				};

				vm.UserReceipts.Add(userReceipt);
			}

			vm.TotalCost = order.DeliveryCost + order.UserOrders
				.SelectMany(uo => uo.FoodOrders)
				.Select(fo => fo.Count * fo.Food.Cost)
				.Sum();

			vm.FoodReceipts = new List<GetFoodOrderVm>();
			foreach(var userOrder in order.UserOrders)
			{
				foreach (var foodOrder in userOrder.FoodOrders)
				{
					var newFoodRecept = new GetFoodOrderVm
					{
						FoodOrderId = foodOrder.Id,
						FoodId = foodOrder.Food.Id,
						Title = foodOrder.Food.Title,
						Comment = foodOrder.Comment,
						Count = foodOrder.Count,
						UserId = userOrder.User.Id,
						UserName = userOrder.User.Name
					};

					vm.FoodReceipts.Add(newFoodRecept);
				}
			}

			vm.FoodGroupedReceipts = new List<FoodGroupedReceiptVm>();
			var foodOrders = order.UserOrders.SelectMany(uo => uo.FoodOrders);
			foreach (var foodOrder in foodOrders)
			{
				var foodReceipt = vm.FoodGroupedReceipts.FirstOrDefault(fr => fr.Title == foodOrder.Food.Title && fr.Comment == foodOrder.Comment);
				if (foodReceipt == null)
				{
					var newFoodRecept = new FoodGroupedReceiptVm
					{
						Title = foodOrder.Food.Title,
						Comment = foodOrder.Comment,
						Count = foodOrder.Count
					};
					vm.FoodGroupedReceipts.Add(newFoodRecept);
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
