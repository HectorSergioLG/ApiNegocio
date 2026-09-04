using Aplication.Identity.Security.Permissions.Common;
using Domain.Entities.Security.Permissions;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Security.Permissions.GetById
{
    public sealed class GetPermissionByIdQueryHandler : IRequestHandler<GetPermissionByIdQuery, ErrorOr<PermissionResponse>>
    {
        private readonly IPermissionRepository _permissionRepository;

        public GetPermissionByIdQueryHandler(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
        }

        public async Task<ErrorOr<PermissionResponse>> Handle(GetPermissionByIdQuery request, CancellationToken cancellationToken)
        {
            if (await _permissionRepository.GetById(new PermissionId(request.Id)) is not Permission permission)
            {
                return Error.NotFound("Permission.NotFound", "El permiso no fue encontrado.");
            }

            return new PermissionResponse(
                permission.Id.Value,
                permission.Name
            );
        }
    }
}
