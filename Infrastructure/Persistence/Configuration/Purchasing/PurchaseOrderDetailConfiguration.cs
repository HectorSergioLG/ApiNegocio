using Domain.Entities.Catalogs.Products.Products;
using Domain.Entities.Purchasing.PurchaseOrders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration.Purchasing
{
    public sealed class PurchaseOrderDetailConfiguration : IEntityTypeConfiguration<PurchaseOrderDetail>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderDetail> builder)
        {
            builder.ToTable("PurchaseOrderDetails");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id).HasConversion(id => id.Value, value => new PurchaseOrderDetailId(value));

            builder.Property(d => d.PurchaseOrderId).HasConversion(id => id.Value, value => new PurchaseOrderId(value));

            builder.Property(d => d.ProductId).HasConversion(id => id.Value, value => new ProductId(value)).IsRequired();

            builder.Property(d => d.Quantity).HasPrecision(18, 4).IsRequired();
            builder.Property(d => d.UnitPrice).HasPrecision(18, 4).IsRequired();
        }

    }
}
