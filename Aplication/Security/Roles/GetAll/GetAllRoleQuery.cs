using Aplication.Security.Roles.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Security.Roles.GetAll
{
    public record GetAllRoleQuery() : IRequest<ErrorOr<IReadOnlyList<RoleResponse>>>;

}
