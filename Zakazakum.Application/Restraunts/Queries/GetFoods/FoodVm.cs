using System;
using AutoMapper;
using Zakazakum.Application.Common.Mapping;
using Zakazakum.Domain.Entities;

namespace Zakazakum.Application.Restraunts.Queries.GetFoods
{
	public class FoodVm : IMapFrom<Food>
	{
		public Guid Id { get; set; }

		public string Title { get; set; }

		public float Cost { get; set; }

		public string Description { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Food, FoodVm>();
		}
	}
}
