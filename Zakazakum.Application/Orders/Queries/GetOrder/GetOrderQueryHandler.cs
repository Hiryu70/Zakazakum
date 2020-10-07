using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Zakazakum.Application.Common.Interfaces;
using Zakazakum.Domain.Entities;

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

			vm.DeliveryCostPerUser = (float)Math.Round(order.DeliveryCost / order.UserOrders.Count, 0);

			vm.TotalCost = order.DeliveryCost + order.UserOrders
				.SelectMany(uo => uo.FoodOrders)
				.Select(fo => fo.Count * fo.Food.Cost)
				.Sum();

			vm.UserReceipts = GetUserReceipts(order.UserOrders, vm.DeliveryCostPerUser);

			vm.UserGroupedReceipts = GetUserGroupedReceipts(order.UserOrders, vm.DeliveryCostPerUser);

			vm.FoodReceipts = GetFoodReceipts(order.UserOrders);

			vm.FoodGroupedReceipts = GetFoodGroupedReceipts(order.UserOrders); 

			return vm;
		}

		private List<UserReceiptVm> GetUserReceipts(List<UserOrder> userOrders, float deliveryCostPerUser)
		{
			var userReceipts = new List<UserReceiptVm>();

			foreach (var userOrder in userOrders)
			{
				var foodCost = userOrder.FoodOrders.Select(fo => fo.Count * fo.Food.Cost).Sum();

				var userReceipt = new UserReceiptVm()
				{
					FoodCost = foodCost,
					DeliveryCost = deliveryCostPerUser,
					Total = foodCost + deliveryCostPerUser,
					Name = userOrder.User.Name,
					IsOrderPaid = userOrder.IsOrderPaid,
					UserId = userOrder.User.Id
				};

				userReceipts.Add(userReceipt);
			}

			return userReceipts;
		}


		private List<UserGroupedReceiptVm> GetUserGroupedReceipts(List<UserOrder> userOrders, float deliveryCostPerUser)
		{
			var userGroupedReceipts = new List<UserGroupedReceiptVm>();

			foreach (var userOrder in userOrders)
			{
				var foodCost = userOrder.FoodOrders.Select(fo => fo.Count * fo.Food.Cost).Sum();

				var userReceipt = new UserGroupedReceiptVm()
				{
					FoodCost = foodCost,
					DeliveryCost = deliveryCostPerUser,
					Total = foodCost + deliveryCostPerUser,
					Name = userOrder.User.Name,
					IsOrderPaid = userOrder.IsOrderPaid,
					UserId = userOrder.User.Id
				};

				userReceipt.FoodOrders = new List<GetFoodOrderVm>();
				foreach (var foodOrder in userOrder.FoodOrders)
				{
					var newFoodRecept = new GetFoodOrderVm
					{
						FoodOrderId = foodOrder.Id,
						FoodId = foodOrder.Food.Id,
						Title = foodOrder.Food.Title,
						Cost = foodOrder.Food.Cost,
						Comment = foodOrder.Comment,
						Count = foodOrder.Count,
						UserId = userOrder.User.Id,
						UserName = userOrder.User.Name
					};

					userReceipt.FoodOrders.Add(newFoodRecept);
				}

				userGroupedReceipts.Add(userReceipt);
			}

			return userGroupedReceipts;
		}

		private List<GetFoodOrderVm> GetFoodReceipts(List<UserOrder> userOrders)
		{
			var foodReceipts = new List<GetFoodOrderVm>();

			foreach (var userOrder in userOrders)
			{
				foreach (var foodOrder in userOrder.FoodOrders)
				{
					var newFoodRecept = new GetFoodOrderVm
					{
						FoodOrderId = foodOrder.Id,
						FoodId = foodOrder.Food.Id,
						Title = foodOrder.Food.Title,
						Cost = foodOrder.Food.Cost,
						Comment = foodOrder.Comment,
						Count = foodOrder.Count,
						UserId = userOrder.User.Id,
						UserName = userOrder.User.Name
					};

					foodReceipts.Add(newFoodRecept);
				}
			}

			return foodReceipts;
		}

		private List<FoodGroupedReceiptVm> GetFoodGroupedReceipts(List<UserOrder> userOrders)
		{
			var foodGroupedReceipts = new List<FoodGroupedReceiptVm>();

			var foodOrders = userOrders.SelectMany(uo => uo.FoodOrders);
			foreach (var foodOrder in foodOrders)
			{
				var foodReceipt = foodGroupedReceipts.FirstOrDefault(fr => fr.Title == foodOrder.Food.Title && fr.Comment == foodOrder.Comment);
				if (foodReceipt == null)
				{
					var newFoodRecept = new FoodGroupedReceiptVm
					{
						Title = foodOrder.Food.Title,
						Comment = foodOrder.Comment,
						Count = foodOrder.Count
					};
					foodGroupedReceipts.Add(newFoodRecept);
				}
				else
				{
					foodReceipt.Count += foodOrder.Count;
				}
			}

			return foodGroupedReceipts;
		}
	}
}
