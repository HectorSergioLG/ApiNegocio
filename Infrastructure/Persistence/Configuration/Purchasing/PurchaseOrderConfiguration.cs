using Domain.Entities.Catalogs.Companies;
using Domain.Entities.Purchasing.PurchaseOrders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration.Purchasing
{
    public sealed class PurchaseOrderConfiguration : IEntityTypeConfiguration<PurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            builder.ToTable("PurchaseOrders");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasConversion(id => id.Value, id => new PurchaseOrderId(id));
            builder.Property(p => p.CompanyId).HasConversion(id => id.Value, id => new CompanyId(id)).IsRequired();
            builder.Property(p => p.OrderNumber).HasMaxLength(50).IsRequired();
            builder.HasIndex(p => p.OrderNumber).IsUnique();
            builder.Property(p => p.OrderDate).IsRequired();
            builder.Property(p => p.Status).HasConversion<int>().IsRequired();
            builder.Ignore(p => p.TotalAmount);

            // Configuración de los detalles (One-to-Many)
            builder.HasMany(p => p.Details)
                .WithOne()
                .HasForeignKey(d => d.PurchaseOrderId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
