using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zakazakum.Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using Zakazakum.EntityFramework.Identity;

namespace Zakazakum.EntityFramework
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddMySql(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ZakazakumContext>(options =>
				options.UseMySql(configuration.GetConnectionString("MySqlConnection")));

			AddServices(services);
			return services;
		}

		public static IServiceCollection AddMySqlAzure(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<ZakazakumContext>(options => 
				options.UseMySql(connectionString));

			AddServices(services);
			return services;
		}

		public static IServiceCollection AddPostgresql(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ZakazakumContext>(options => 
			options.UseNpgsql(configuration.GetConnectionString("NpgsqlConnection")));

			AddServices(services);
			return services;
		}

		private static void AddServices(IServiceCollection services)
		{
			services.AddScoped<IZakazakumContext>(provider => provider.GetService<ZakazakumContext>());

			services.AddDefaultIdentity<ApplicationUser>()
					.AddEntityFrameworkStores<ZakazakumContext>();

			services.Configure<IdentityOptions>(options =>
			{
				options.Password.RequireDigit = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
				options.Password.RequiredLength = 4;
			});

			services.AddTransient<IIdentityService, IdentityService>();
		}
	}
}
