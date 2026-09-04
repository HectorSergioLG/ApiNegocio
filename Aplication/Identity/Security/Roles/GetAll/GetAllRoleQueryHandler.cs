using Aplication.Identity.Security.Roles.Common;
using Domain.Entities.Security.Roles;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Security.Roles.GetAll
{
    public sealed class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, ErrorOr<IReadOnlyList<RoleResponse>>>
    {
        private readonly IRoleRepository _roleRepository;

        public GetAllRoleQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<ErrorOr<IReadOnlyList<RoleResponse>>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Role> Roles = await _roleRepository.GetAll();
            return Roles.Select(role => new RoleResponse(
               role.Id.Value,
               role.Name,
               role.Permissions.Select(s => s.Id.Value.ToString()).ToList(),
               role.IsActive
             )).ToList();
        }

        
    }
}
