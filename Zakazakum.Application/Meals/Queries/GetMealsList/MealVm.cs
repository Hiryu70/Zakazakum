using System;
using AutoMapper;
using Zakazakum.Application.Common.Mapping;
using Zakazakum.Domain;
using Zakazakum.Domain.Entities;

namespace Zakazakum.Application.Meals.Queries.GetMealsList
{
	public class MealVm : IMapFrom<Meal>
	{
		public Guid Id { get; set; }

		public string Title { get; set; }

		public float Cost { get; set; }

		public string Description { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Meal, MealVm>();
		}
	}
}
