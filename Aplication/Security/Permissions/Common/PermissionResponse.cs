using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Security.Permissions.Common
{
    public record PermissionResponse(
        Guid id,
        string Name
    );
}
