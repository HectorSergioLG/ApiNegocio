using Domain.Entities.Catalogs.Products.Products;
using Domain.Entities.Purchasing.PurchaseReceipts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration.Purchasing
{
    internal class PurchaseReceiptDetailConfiguration : IEntityTypeConfiguration<PurchaseReceiptDetail>
    {
        public void Configure(EntityTypeBuilder<PurchaseReceiptDetail> builder)
        {
            builder.ToTable("PurchaseReceiptDetails");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id)
                .HasConversion(id => id.Value, value => new PurchaseReceiptDetailId(value));

            builder.Property(d => d.PurchaseReceiptId)
                .HasConversion(id => id.Value, value => new PurchaseReceiptId(value));

            builder.Property(d => d.ProductId)
                .HasConversion(id => id.Value, value => new ProductId(value))
                .IsRequired();

            builder.Property(d => d.ReceivedQuantity).HasPrecision(18, 4).IsRequired();
            builder.Property(d => d.UnitCost).HasPrecision(18, 4).IsRequired();
        }
    }
}
