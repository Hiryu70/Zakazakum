using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zakazakum.Domain.Entities;

namespace Zakazakum.EntityFramework.Configurations
{
	public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
	{
		public void Configure(EntityTypeBuilder<Restaurant> builder)
		{
			builder.Property(e => e.Id)
				.HasColumnName("Id")
				.ValueGeneratedOnAdd();

			builder.Property(e => e.Title)
				.IsRequired()
				.HasMaxLength(100);
		}
	}
}
