using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Security.Roles.Update
{
    public record class UpdateRoleCommand(
        Guid Id,
        string Name,
        List<string> PermissionIds
        ) : IRequest<ErrorOr<Unit>>;
}
