using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zakazakum.Application.Common.Interfaces;

namespace Zakazakum.EntityFramework
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddMySql(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ZakazakumContext>(options =>
				options.UseMySql(configuration.GetConnectionString("MySqlConnection")));

			services.AddScoped<IZakazakumContext>(provider => provider.GetService<ZakazakumContext>());

			return services;
		}

		public static IServiceCollection AddMySqlAzure(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<ZakazakumContext>(options => options.UseMySql(connectionString));
			services.AddScoped<IZakazakumContext>(provider => provider.GetService<ZakazakumContext>());

			return services;
		}

		public static IServiceCollection AddPostgresql(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ZakazakumContext>(options =>
				options.UseNpgsql(configuration.GetConnectionString("NpgsqlConnection")));

			services.AddScoped<IZakazakumContext>(provider => provider.GetService<ZakazakumContext>());

			return services;
		}
	}
}
