using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Security.Permissions.Delete
{
    public  record DeletePermissionCommand (Guid Id) :IRequest<ErrorOr.ErrorOr<Unit>>;
}
