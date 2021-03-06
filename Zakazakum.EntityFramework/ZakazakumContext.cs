﻿using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;
using Zakazakum.Domain.Entities;

namespace Zakazakum.EntityFramework
{
	public class ZakazakumContext : DbContext, IZakazakumContext
	{
		public ZakazakumContext(DbContextOptions<ZakazakumContext> options) : base(options)
		{
		}


		public DbSet<Restaurant> Restaurants { get; set; }

		public DbSet<Order> Orders { get; set; }

		public DbSet<User> Users { get; set; }

		public DbSet<UserOrder> UserOrders { get; set; }
	}
}