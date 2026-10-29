using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Security.Roles.Common
{
    public record RoleResponse(

        Guid id,
        string Name,
        List<string> idPermissions,
        bool isActive
    );
}
