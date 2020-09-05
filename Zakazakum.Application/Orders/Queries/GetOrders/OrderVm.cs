using System;
using AutoMapper;
using Zakazakum.Application.Common.Mapping;
using Zakazakum.Domain.Entities;

namespace Zakazakum.Application.Orders.Queries.GetOrders
{
	public class OrderVm : IMapFrom<Order>
	{
		public int Id { get; set; }

		public string OwnerName { get; set; }

		public DateTime Created { get; set; }

		public string RestaurantTitle { get; set; }


		public void Mapping(Profile profile)
		{
			profile.CreateMap<Order, OrderVm>()
				.ForMember(vm => vm.OwnerName, opt => opt.MapFrom(m => m.Owner.Name))
				.ForMember(vm => vm.RestaurantTitle, opt => opt.MapFrom(m => m.Restaurant.Title));
		}
	}
}
