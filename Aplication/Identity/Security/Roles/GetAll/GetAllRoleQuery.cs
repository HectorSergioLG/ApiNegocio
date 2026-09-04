using Aplication.Identity.Security.Roles.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Security.Roles.GetAll
{
    public record GetAllRoleQuery() : IRequest<ErrorOr<IReadOnlyList<RoleResponse>>>;

}
