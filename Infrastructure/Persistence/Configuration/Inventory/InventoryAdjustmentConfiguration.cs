using Domain.Entities.Inventory.InventoryAdjustments;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Catalogs.Products.Products;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configuration.Inventory
{
    public sealed class InventoryAdjustmentConfiguration : IEntityTypeConfiguration<InventoryAdjustment>
    {
        public void Configure(EntityTypeBuilder<InventoryAdjustment> builder)
        {
            builder.ToTable("InventoryAdjustments");
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .HasConversion(id => id.Value, value => new InventoryAdjustmentId(value));

            builder.Property(i => i.WarehouseId).IsRequired();

            builder.Property(i => i.ProductId)
                .HasConversion(id => id.Value, value => new ProductId(value))
                .IsRequired();

            builder.Property(i => i.AdjustedQuantity).HasPrecision(18, 4).IsRequired();
            builder.Property(i => i.Reason).HasMaxLength(250).IsRequired();
            builder.Property(i => i.AdjustmentDate).IsRequired();
            builder.Property(i => i.Status).HasConversion<int>().IsRequired();
        }
    }
}
