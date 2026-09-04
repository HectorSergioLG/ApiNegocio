using Aplication.Identity.Security.Roles.Common;
using Domain.Entities.Security.Roles;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Security.Roles.GetById
{
    public sealed class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, ErrorOr<RoleResponse>> //IRequest<ErrorOr<IReadOnlyList<RolesResponse>>>
    {
        private readonly IRoleRepository _roleRepository;

        public GetRoleByIdQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<ErrorOr<RoleResponse>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            if (await _roleRepository.GetById(new RoleId(request.Id)) is not Role role)
            {
                return Error.NotFound("Role.NotFound", "El rol no fue encontrado.");
            }

            return new RoleResponse(
                role.Id.Value,
                role.Name,
                role.Permissions.Select(s => s.Id.Value.ToString()).ToList(),
                role.IsActive
            );
        }
    }
}
