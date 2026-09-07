using Domain.Entities.Security.Permissions;
using Domain.Entities.Security.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration.Security
{
    public class RoleConfiguracion : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .HasConversion(id => id.Value, id => new RoleId(id));

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(r => r.IsActive)
                .HasDefaultValue(true);

            // Relación many-to-many con Permission
            builder.HasMany(r => r.Permissions)
                .WithMany()
                .UsingEntity(
                    "RolePermission",
                    l => l.HasOne(typeof(Permission))
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade),
                    r => r.HasOne(typeof(Role))
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j.HasKey("RoleId", "PermissionId"));
        }
    }
}
