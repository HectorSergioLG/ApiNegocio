using Aplication.Identity.Security.Roles.Common;
using Domain.Entities.Security.Roles;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Security.Roles.GetById
{
    public record GetRoleByIdQuery(Guid Id) : IRequest<ErrorOr<RoleResponse>>;
}
