using Domain.Entities.Catalogs.Companies;
using Domain.Entities.Catalogs.Products.Products;
using Domain.Entities.Inventory.InventoryMovements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration.Inventory
{
    public sealed class InventoryMovementConfiguration : IEntityTypeConfiguration<InventoryMovement>
    {
        public void Configure(EntityTypeBuilder<InventoryMovement> builder)
        {
            builder.ToTable("InventoryMovements");
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .HasConversion(id => id.Value, value => new InventoryMovementId(value));

            builder.Property(i => i.CompanyId)
                .HasConversion(id => id.Value, value => new CompanyId(value))
                .IsRequired();

            builder.Property(i => i.WarehouseId).IsRequired();

            builder.Property(i => i.ProductId)
                .HasConversion(id => id.Value, value => new ProductId(value))
                .IsRequired();

            builder.Property(i => i.Type).HasConversion<int>().IsRequired();
            builder.Property(i => i.Quantity).HasPrecision(18, 4).IsRequired();
            builder.Property(i => i.ReferenceDocument).HasMaxLength(100).IsRequired();
            builder.Property(i => i.MovementDate).IsRequired();
            builder.Property(i => i.CreatedBy).IsRequired();
        }
    }
}
