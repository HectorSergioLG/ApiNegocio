using Domain.Entities.Catalogs.Companies;
using Domain.ValueObjects;
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

            // Primary Key & Conversion de Strongly-Typed ID
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasConversion(id => id.Value, value => new CompanyId(value));

            // Propiedades básicas
            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.TradeName)
                .HasMaxLength(100)
                .IsRequired();

            // Mapeo / Conversión de Value Objects
            builder.Property(c => c.Email)
                .HasConversion(email => email.Value, value => Email.Create(value)!)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.PhoneNumber)
                .HasConversion(phone => phone.Value, value => PhoneNumber.Create(value)!)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.IsActive)
                .IsRequired();
        }
    }

}
