using Domain.Entities.Security.Permissions;
using Domain.Primitives;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Security.Permissions.Delete
{
    internal sealed class DeletePermissionCommandHandler : IRequestHandler<DeletePermissionCommand, ErrorOr<Unit>>
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePermissionCommandHandler(IPermissionRepository permissionRepository, IUnitOfWork unitOfWork)
        {
            _permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
        {
            if (await _permissionRepository.GetById(new PermissionId(request.Id)) is not Permission permission)
            {
                return Error.NotFound("Permission","Permission not found");
            }

           _permissionRepository.Delete(permission);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}
