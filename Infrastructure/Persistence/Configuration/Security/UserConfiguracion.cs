
using Domain.Entities.Security.Roles;
using Domain.Entities.Security.Users;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration.Security
{
    public class UserConfiguracion : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u=> u.Id);
            builder.Property(u => u.Id).HasConversion(id => id.Value, id => new UserId(id));

            builder.Property(u => u.Name).IsRequired().HasMaxLength(150);
            builder.Property(u => u.FistLastName).HasMaxLength(150);
            builder.Property(u => u.SecondLastName).HasMaxLength(150);
            builder.Property(u => u.Email).HasConversion(correoElectronico => correoElectronico.Value, value => Email.Create(value)).HasMaxLength(150);
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(150);
            builder.Property(U => U.Password).HasConversion(contrasenia => contrasenia.Value, value => Password.Create(value));
            builder.Property(u => u.RegistrationDate);
            builder.Property(u => u.IsActive);

            // Relación many-to-many con Role
            builder.HasMany(u => u.Roles)
                .WithMany()
                .UsingEntity("UserRole",
                    l => l.HasOne(typeof(Role)).WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.Cascade),
                    r => r.HasOne(typeof(User)).WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.Cascade),
                    j => j.HasKey("UserId", "RoleId"));
        }
    }
}
