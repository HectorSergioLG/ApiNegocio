using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Security.Permissions.Common
{
    public record PermissionResponse(
        Guid id,
        string Name
    );
}
