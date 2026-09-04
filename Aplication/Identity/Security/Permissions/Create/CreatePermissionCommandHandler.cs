using Domain.Entities.Security.Permissions;
using Domain.Entities.Security.Roles;
using Domain.Primitives;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Aplication.Identity.Security.Permissions.Create
{
    internal sealed class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, ErrorOr<Unit>>
    {
        private readonly IPermissionRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePermissionCommandHandler(IPermissionRepository permissionRepository, IUnitOfWork unitOfWork)
        {
            _roleRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return Error.Validation("Name.Empty", "El nombre del permiso no puede estar vacio");
            }
            var permission = new Permission(
                new PermissionId(Guid.NewGuid()),
                request.Name
            );
            _roleRepository.Add(permission);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
