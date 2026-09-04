using Aplication.Identity.Security.Permissions.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Security.Permissions.GetAll
{
    public record GetAllPermissionQuery() : IRequest<ErrorOr<IReadOnlyList<PermissionResponse>>>; 
}