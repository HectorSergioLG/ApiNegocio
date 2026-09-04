using Domain.Entities.Security.Permissions;
using Domain.Primitives;
using ErrorOr;

namespace Domain.Entities.Security.Roles
{
    public class Role : AggregateRoot
    {
        public Role() { }
        public Role(RoleId id, string? name, bool isActive)
        {
            Id = id;
            Name = name;
            IsActive = isActive;
        }

        public RoleId Id { get; private set; }
        public string? Name { get; private set; } = string.Empty;
        public bool IsActive { get; private set; } = true;


        public List<Permission> Permissions { get; private set; }

        public void AssignPermission(Permission permission)
        {
            if (!Permissions.Contains(permission))
            {
                Permissions.Add(permission);
            }
        }

        public void RemovePermission(Permission permission)
        {
            if (!Permissions.Contains(permission))
            {
                Permissions.Remove(permission);
            }
        }

        public void Disable()
        {
            IsActive = false;
        }
        public void Enable()
        {
            IsActive = true;
        }

        public static Role UpdateRole(RoleId id, string? name, List<Permission> permissions)
        {
            return new Role
            {
                Id = id,
                Name = name,
                Permissions = permissions
            };
        }
    }
}
