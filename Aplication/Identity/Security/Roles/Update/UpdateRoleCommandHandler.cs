using Domain.Entities.Security.Roles;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Security.Roles.Update
{
    public sealed class UpdateRoleCommandHandler: IRequestHandler<UpdateRoleCommand, ErrorOr<Unit>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRoleCommandHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
        {
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork)); 
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {

            if(request.PermissionIds.Count() == 0)
            {

                return Error.Validation("Permission.Empty", "El rol debe tener al menos un permiso");
            }

            Role role = Role.UpdateRole(new RoleId(Guid.NewGuid()), request.Name, new());

            foreach (var item in request.PermissionIds)
            {
                //role.AssignPermission()//obtenre el permiso por id ya signarlo a la lista
            }   

            _roleRepository.Update(role);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;


        }
    }
}
