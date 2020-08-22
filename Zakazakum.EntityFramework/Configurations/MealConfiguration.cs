using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zakazakum.Domain.Entities;

namespace Zakazakum.EntityFramework.Configurations
{
	public class MealConfiguration : IEntityTypeConfiguration<Meal>
	{
		public void Configure(EntityTypeBuilder<Meal> builder)
		{
			builder.Property(e => e.Id)
				.HasColumnName("Id")
				.ValueGeneratedOnAdd();

			builder.Property(e => e.Title)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(e => e.Cost);

			builder.Property(e => e.Description)
				.HasMaxLength(200);
		}
	}
}
