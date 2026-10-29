using Domain.Entities.Catalogs.Products.Products;
using Domain.Entities.Inventory.ProductBatches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration.Inventory
{
    public sealed class ProductBatchConfiguration : IEntityTypeConfiguration<ProductBatch>
    {
        public void Configure(EntityTypeBuilder<ProductBatch> builder)
        {
            builder.ToTable("ProductBatches");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasConversion(id => id.Value, value => new ProductBatchId(value));

            builder.Property(p => p.ProductId)
                .HasConversion(id => id.Value, value => new ProductId(value))
                .IsRequired();

            builder.Property(p => p.BatchNumber).HasMaxLength(100).IsRequired();
            builder.Property(p => p.ManufactureDate).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();

            builder.HasIndex(p => new { p.ProductId, p.BatchNumber }).IsUnique();
        }
    }
}
