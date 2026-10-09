using Domain.Entities.Catalogs.Companies;
using Domain.Entities.Purchasing.PurchaseOrders;
using Domain.Entities.Purchasing.PurchaseReceipts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration.Purchasing
{
    public sealed class PurchaseReceiptConfiguration : IEntityTypeConfiguration<PurchaseReceipt>
    {
        public void Configure(EntityTypeBuilder<PurchaseReceipt> builder) 
        {
            builder.ToTable("PurchaseReceipts");

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .HasConversion(id => id.Value, value => new PurchaseReceiptId(value));

            builder.Property(r => r.CompanyId)
                .HasConversion(id => id.Value, value => new CompanyId(value))
                .IsRequired();

            builder.Property(r => r.PurchaseOrderId)
                .HasConversion(id => id.Value, value => new PurchaseOrderId(value))
                .IsRequired();

            builder.Property(r => r.WarehouseId).IsRequired();
            builder.Property(r => r.ReceiptNumber).HasMaxLength(50).IsRequired();
            builder.HasIndex(r => r.ReceiptNumber).IsUnique();

            builder.Property(r => r.ReceiptDate).IsRequired();

            builder.HasMany(r => r.Details)
                .WithOne()
                .HasForeignKey(d => d.PurchaseReceiptId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
