using Domain.Entities.Inventory.WarehouseLocations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration.Inventory
{
    public sealed class WarehouseLocationConfiguration : IEntityTypeConfiguration<WarehouseLocation>
    {
        public void Configure(EntityTypeBuilder<WarehouseLocation> builder)
        {
            builder.ToTable("WarehouseLocations");
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Id)
                .HasConversion(id => id.Value, value => new WarehouseLocationId(value));

            builder.Property(w => w.WarehouseId).IsRequired();
            builder.Property(w => w.Code).HasMaxLength(50).IsRequired();
            builder.Property(w => w.Description).HasMaxLength(200);
            builder.Property(w => w.IsActive).IsRequired();

            builder.HasIndex(w => new { w.WarehouseId, w.Code }).IsUnique();
        }
    }
}
