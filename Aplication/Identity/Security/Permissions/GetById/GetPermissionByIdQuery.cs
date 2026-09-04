using Aplication.Identity.Security.Permissions.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Security.Permissions.GetById
{
    public record GetPermissionByIdQuery(Guid Id) : IRequest<ErrorOr<PermissionResponse>>;
   
}
