using Domain.Entities.Security.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Security.Permissions
{
    public interface IPermissionRepository
    {
        Task<List<Permission>> GetAll();
        Task<Permission?> GetById(PermissionId id);
        Task<bool> Exists(PermissionId id);
        void Add(Permission role);
        void Delete(Permission role);
        void Update(Permission role);
    }
}
