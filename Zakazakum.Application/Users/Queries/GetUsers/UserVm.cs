using System;
using AutoMapper;
using Zakazakum.Application.Common.Mapping;
using Zakazakum.Domain.Entities;

namespace Zakazakum.Application.Users.Queries.GetUsers
{
	public class UserVm : IMapFrom<User>
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string PhoneNumber { get; set; }

		public string BankName { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<User, UserVm>();
		}
	}
}
