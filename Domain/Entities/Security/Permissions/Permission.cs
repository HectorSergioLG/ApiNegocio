using Domain.Entities.Security.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Security.Permissions
{
    public class Permission
    {
        public Permission()
        {
        }

        public Permission(PermissionId id, string name)
        {
            Id = id;
            Name = name;
        }

        public PermissionId Id { get; private set; }
        public string Name { get; private set; } = string.Empty;


    }
}
