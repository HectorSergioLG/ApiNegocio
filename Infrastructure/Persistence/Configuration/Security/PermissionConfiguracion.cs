using Domain.Entities.Security.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration.Security
{
    public class PermissionConfiguracion : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasConversion(id => id.Value, id => new PermissionId(id));

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
