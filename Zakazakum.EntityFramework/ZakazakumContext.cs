using Microsoft.EntityFrameworkCore;
using Zakazakum.Application.Common.Interfaces;
using Zakazakum.Domain;
using Zakazakum.Domain.Entities;

namespace Zakazakum.EntityFramework
{
	public class ZakazakumContext : DbContext, IZakazakumContext
	{
		public ZakazakumContext(DbContextOptions<ZakazakumContext> options) : base(options)
		{
		}

		public DbSet<Meal> Meals { get; set; }
	}
}