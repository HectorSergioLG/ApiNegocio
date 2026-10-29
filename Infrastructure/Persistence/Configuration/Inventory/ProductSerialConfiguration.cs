using Domain.Entities.Catalogs.Products.Products;
using Domain.Entities.Inventory.ProductSerials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configuration.Inventory
{
    public sealed class ProductSerialConfiguration : IEntityTypeConfiguration<ProductSerial>
    {
        public void Configure(EntityTypeBuilder<ProductSerial> builder)
        {
            builder.ToTable("ProductSerials");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasConversion(id => id.Value, value => new ProductSerialId(value));

            builder.Property(p => p.ProductId)
                .HasConversion(id => id.Value, value => new  ProductId(value))
                .IsRequired();

            builder.Property(p => p.SerialNumber).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Status).HasConversion<int>().IsRequired();

            builder.HasIndex(p => p.SerialNumber).IsUnique();
        }
    }
}
