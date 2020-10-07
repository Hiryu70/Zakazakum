using System;
using System.Collections.Generic;
using AutoMapper;
using Zakazakum.Application.Common.Mapping;
using Zakazakum.Domain.Entities;
using Zakazakum.Domain.Enums;

namespace Zakazakum.Application.Orders.Queries.GetOrder
{
	public class GetOrderVm : IMapFrom<Order>
	{
		public int Id { get; set; }

		public OrderStatus OrderStatus { get; set; }

		public string OwnerName { get; set; }

		public string OwnerBank { get; set; }

		public string OwnerPhoneNumber { get; set; }

		public DateTime Created { get; set; }

		public string RestaurantTitle { get; set; }

		public Guid RestaurantId { get; set; }

		public float DeliveryCost { get; set; }

		public float DeliveryCostPerUser { get; set; }

		public float TotalCost { get; set; }

		public List<UserReceiptVm> UserReceipts { get; set; }

		public List<UserGroupedReceiptVm> UserGroupedReceipts { get; set; }

		public List<FoodGroupedReceiptVm> FoodGroupedReceipts { get; set; }

		public List<GetFoodOrderVm> FoodReceipts { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Order, GetOrderVm>()
				.ForMember(vm => vm.OwnerName, opt => opt.MapFrom(m => m.Owner.Name))
				.ForMember(vm => vm.RestaurantTitle, opt => opt.MapFrom(m => m.Restaurant.Title))
				.ForMember(vm => vm.RestaurantId, opt => opt.MapFrom(m => m.Restaurant.Id))
				.ForMember(vm => vm.OwnerName, opt => opt.MapFrom(m => m.Owner.Name))
				.ForMember(vm => vm.OwnerBank, opt => opt.MapFrom(m => m.Owner.BankName))
				.ForMember(vm => vm.OwnerPhoneNumber, opt => opt.MapFrom(m => m.Owner.PhoneNumber));
		}
	}
}
