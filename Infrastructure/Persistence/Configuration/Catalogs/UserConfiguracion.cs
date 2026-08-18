
using Domain.Entities.Catalogs.User;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration.Catalogs
{
    public class UserConfiguracion : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(u=> u.Id);
            builder.Property(u => u.Id).HasConversion(id => id.Value, id => new UserId(id));

            builder.Property(u => u.Name).IsRequired().HasMaxLength(150);
            builder.Property(u => u.FistLastName).HasMaxLength(150);
            builder.Property(u => u.SecondLastName).HasMaxLength(150);
            builder.Property(u => u.Email).HasConversion(correoElectronico => correoElectronico.Value, value => Email.Create(value)).HasMaxLength(150);
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(150);
            builder.Property(U => U.Password).HasConversion(contrasenia => contrasenia.Value, value => Password.Create(value));
            builder.Property(u => u.RegistrationDate);
            builder.Property(u => u.Active); 
        }
    }
}
