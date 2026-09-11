using Domain.Entities.Catalogs.Products.Brands;
using Domain.Entities.Catalogs.Products.Products;
using Domain.Entities.Catalogs.Products.UnitsMesures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration.Catalogs
{
    public  class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasConversion(id => id.Value, id => new ProductId(id));
            builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Stock).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();

            // Configuración de la relación con Brand
            builder.HasOne<Brand>()
                .WithMany()
                .HasForeignKey(p=>p.Id)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<UnitMeasure>()
                .WithMany()
                .HasForeignKey(p => p.Id)
                .OnDelete(DeleteBehavior.Restrict);




        }
    }
}
