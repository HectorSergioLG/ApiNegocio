using Aplication.Security.Permissions.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Security.Permissions.GetAll
{
    public record GetAllPermissionQuery() : IRequest<ErrorOr<IReadOnlyList<PermissionResponse>>>; 
}