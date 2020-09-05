using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.EntityFramework
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddSqlite(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ZakazakumContext>(options =>
				options.UseSqlite(configuration.GetConnectionString("SqliteConnection")));

			services.AddScoped<IZakazakumContext>(provider => provider.GetService<ZakazakumContext>());

			return services;
		}

		public static IServiceCollection AddMySql(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ZakazakumContext>(options =>
				options.UseMySql(configuration.GetConnectionString("MySqlConnection")));

			services.AddScoped<IZakazakumContext>(provider => provider.GetService<ZakazakumContext>());

			return services;
		}
	}
}
