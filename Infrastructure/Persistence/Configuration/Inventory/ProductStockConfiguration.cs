using Domain.Entities.Catalogs.Companies;
using Domain.Entities.Inventory.ProductStocks;
using Domain.Entities.Catalogs.Products.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configuration.Inventory
{
    public sealed class ProductStockConfiguration : IEntityTypeConfiguration<ProductStock>
    {
        public void Configure(EntityTypeBuilder<ProductStock> builder)
        {
            builder.ToTable("ProductStocks");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasConversion(id => id.Value, value => new ProductStockId(value));

            builder.Property(p => p.CompanyId)
                .HasConversion(id => id.Value, value => new CompanyId(value))
                .IsRequired();

            builder.Property(p => p.WarehouseId).IsRequired();

            builder.Property(p => p.ProductId)
                .HasConversion(id => id.Value, value => new ProductId(value))
                .IsRequired();

            builder.Property(p => p.PhysicalQuantity).HasPrecision(18, 4).IsRequired();
            builder.Property(p => p.ReservedQuantity).HasPrecision(18, 4).IsRequired();
            builder.Ignore(p => p.AvailableQuantity);

            builder.HasIndex(p => new { p.CompanyId, p.WarehouseId, p.ProductId }).IsUnique();
        }
    }
}
