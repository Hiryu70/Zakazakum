using System;
using System.Collections.Generic;
using AutoMapper;
using Zakazakum.Application.Common.Mapping;
using Zakazakum.Domain.Entities;

namespace Zakazakum.Application.Orders.Queries.GetOrder
{
	public class GetOrderVm : IMapFrom<Order>
	{
		public int Id { get; set; }

		public string OwnerName { get; set; }

		public string OwnerBank { get; set; }

		public string OwnerPhoneNumber { get; set; }

		public DateTime Created { get; set; }

		public string RestaurantTitle { get; set; }

		public float DeliveryCost { get; set; }

		public float DeliveryCostPerUser { get; set; }

		public List<UserReceiptVm> UserReceipts { get; set; }

		public List<FoodReceiptVm> FoodReceipts { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Order, GetOrderVm>()
				.ForMember(vm => vm.OwnerName, opt => opt.MapFrom(m => m.Owner.Name))
				.ForMember(vm => vm.RestaurantTitle, opt => opt.MapFrom(m => m.Restaurant.Title));
		}
	}
}
