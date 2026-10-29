using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Security.Permissions.Create
{
    public record CreatePermissionCommand(
        string Name
        ) : IRequest<ErrorOr<Unit>>;
}
