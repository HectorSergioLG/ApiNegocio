using Domain.Entities.Catalogs.Products.UnitsMesures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration.Catalogs
{
    public class UnitMeasureConfiguration : IEntityTypeConfiguration<UnitMeasure>
    {
        public void Configure(EntityTypeBuilder<UnitMeasure> builder)
        { 
            builder.ToTable("UnitMeasures");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasConversion(id => id.Value, id => new UnitMeasureId(id));

            builder.Property(c => c.Name).IsRequired().HasMaxLength(150);
            builder.Property(c => c.Abbreviation).IsRequired().HasMaxLength(10);
            builder.Property(c => c.Description).HasMaxLength(500);
        }
    }
}