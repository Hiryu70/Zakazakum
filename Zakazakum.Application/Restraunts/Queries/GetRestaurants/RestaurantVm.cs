using System;
using AutoMapper;
using Zakazakum.Application.Common.Mapping;
using Zakazakum.Domain.Entities;

namespace Zakazakum.Application.Restraunts.Queries.GetRestaurants
{
	public class RestaurantVm : IMapFrom<Restaurant>
	{
		public Guid Id { get; set; }

		public string Title { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Restaurant, RestaurantVm>();
		}
	}
}
