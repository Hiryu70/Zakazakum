using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zakazakum.Domain.Entities;

namespace Zakazakum.EntityFramework.Configurations
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.Property(e => e.Id)
				.HasColumnName("Id")
				.ValueGeneratedOnAdd();
		}
	}
}
