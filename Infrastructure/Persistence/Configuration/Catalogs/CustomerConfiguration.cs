using Domain.Entities.Catalogs.Customer;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration.Catalogs
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        /// <summary>
        /// Configura la entidad Customer en el modelo de datos.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);
            builder.Property(c=> c.Id).HasConversion(id => id.Value, id => new CustomerId(id));

            builder.Property(c => c.Name).IsRequired().HasMaxLength(150);
            builder.Property(c => c.FistLastName).IsRequired().HasMaxLength(150);
            builder.Property(c => c.SecondLastName).IsRequired().HasMaxLength(150);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(150);
            builder.Property(c => c.PhoneNumber).HasConversion(telfofono => telfofono.Value, value  => PhoneNumber.Create(value)!).HasMaxLength(10);
            builder.Property(c => c.Active);
        }
    }
}
