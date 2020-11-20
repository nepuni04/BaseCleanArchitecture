using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Ignore domain events as it is not at entity
            builder.Ignore(p => p.DomainEvents);

            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(80);

            builder.Property(p => p.Description).IsRequired().HasMaxLength(180);

            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");

            builder.Property(p => p.PictureUrl).HasMaxLength(50);

            builder.HasOne(b => b.ProductType).WithMany()
                .HasForeignKey(p => p.ProductTypeId);
        }
    }
}