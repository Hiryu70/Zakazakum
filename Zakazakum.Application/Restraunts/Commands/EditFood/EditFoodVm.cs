using System;
using AutoMapper;
using Zakazakum.Application.Common.Mapping;
using Zakazakum.Domain.Entities;

namespace Zakazakum.Application.Restraunts.Commands.EditFood
{
	public class EditFoodVm : IMapFrom<Food>
	{
		public Guid Id { get; set; }

		public string Title { get; set; }

		public float Cost { get; set; }

		public string Description { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<EditFoodVm, Food>();
		}
	}
}
