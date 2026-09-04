using Domain.Entities.Security.Roles;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Security.Roles.Create
{
    internal sealed class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, ErrorOr<Unit>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoleCommandHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
        {
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Unit>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
             return Error.Validation("Name.Empty", "El nombre del rol no puede estar vacio");
            }
            if(request.IdPermissions.Count() == 0)
            {
               return Error.Validation("Permission.Empty", "El rol debe tener al menos un permiso");
            }

            var role = new Role(
                new RoleId(Guid.NewGuid()),
                request.Name,
                request.IsActive
            );

            foreach ( var roleId in request.IdPermissions)
            {

                /// role.AssignPermission(permission); obtner el permiso por id y asignarlo al rol
            }

            _roleRepository.Add(role);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
