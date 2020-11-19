using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config.PurchaseAggregate
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(s => s.SupplierName).HasMaxLength(50).IsRequired();
            builder.Property(s => s.PhoneNo).HasMaxLength(10).IsRequired();
            builder.Property(s => s.AlternatePhoneNo).HasMaxLength(10);
            builder.Property(s => s.Email).HasMaxLength(30);

            builder.OwnsOne(s => s.Address, a => {
                a.WithOwner();
                a.Property(p => p.Street).HasMaxLength(50).IsRequired();
                a.Property(p => p.City).HasMaxLength(25).IsRequired();
                a.Property(p => p.State).HasMaxLength(25).IsRequired();
                a.Property(p => p.Zipcode).HasMaxLength(10).IsRequired();
            });
        }
    }
}
