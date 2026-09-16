using Domain.Entities.Catalogs.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configuration.Catalogs
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasConversion(id => id.Value, id => new CompanyId(id));
            builder.Property(c => c.Name).IsRequired().HasMaxLength(150);
            builder.Property(c => c.IsActive);
        }
    }

}
