using Microsoft.EntityFrameworkCore;
using Zakazakum.Domain.Entities;

namespace Zakazakum.Application.Common.Interfaces
{
	public interface IZakazakumContext
	{
		DbSet<Restaurant> Restaurants { get; set; }

		DbSet<Order> Orders { get; set; }

		DbSet<User> Users { get; set; }

		DbSet<UserOrder> UserOrders { get; set; }
	}
}