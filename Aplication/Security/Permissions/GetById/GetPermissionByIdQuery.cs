using Aplication.Security.Permissions.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Security.Permissions.GetById
{
    public record GetPermissionByIdQuery(Guid Id) : IRequest<ErrorOr<PermissionResponse>>;
   
}
