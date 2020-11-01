using System;
using System.IO;
using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Zakazakum.API.Common;
using Zakazakum.Application;
using Zakazakum.Application.Common.Interfaces;
using Zakazakum.EntityFramework;

namespace Zakazakum.API
{
	/// <summary>
	/// Startup class
	/// </summary>
	public class Startup
	{
		/// <summary>
		/// Startup constructor
		/// </summary>
		/// <param name="configuration"></param>
		/// <param name="environment"></param>
		public Startup(IConfiguration configuration, IWebHostEnvironment environment)
		{
			Configuration = configuration;
			WebHostEnvironment = environment;
		}

		/// <summary>
		/// Application configuration properties
		/// </summary>
		public IConfiguration Configuration { get; }

		/// <summary>
		/// Hosting environment
		/// </summary>
		private IWebHostEnvironment WebHostEnvironment { get; set; }

		/// <summary>
		/// This method gets called by the runtime. Use this method to add services to the container
		/// </summary>
		/// <param name="services">Collection of service descriptors</param>
		public void ConfigureServices(IServiceCollection services)
		{
			if (WebHostEnvironment.IsProduction())
			{
				services.AddMySqlAzure(Environment.GetEnvironmentVariable("MYSQLCONNSTR_zakazakum").ToString());
			}
			else
			{
				services.AddMySql(Configuration);
			}

			services.AddApplication();

			services.AddRouting(options => options.LowercaseUrls = true);

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "Zakazakum",
					Version = "v1"
				});

				var docFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var docFilePath = Path.Combine(AppContext.BaseDirectory, docFile);

				c.IncludeXmlComments(docFilePath);
			});

			

			services.AddControllers().AddNewtonsoftJson(options =>
			{
				options.SerializerSettings.ContractResolver = new DefaultContractResolver();
			})
				.AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null)
				.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IZakazakumContext>());
		}

		/// <summary>
		/// This method gets called by the runtime. Use this method to configure the HTTP request pipeline
		/// </summary>
		/// <param name="app"></param>
		/// <param name="env"></param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Zakazakum API");
				c.RoutePrefix = "swagger";
			});

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseCustomExceptionHandler();

			var siteUrl = Configuration.GetValue<string>("SiteUrl");
			app.UseCors(options =>
				options.WithOrigins(siteUrl)
					.AllowAnyMethod()
					.AllowAnyHeader());

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}

}
