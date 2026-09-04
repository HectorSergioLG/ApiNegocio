using Aplication.Identity.Security.Permissions.Common;
using Domain.Entities.Security.Permissions;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Security.Permissions.GetAll
{
    public class GetAllPermissionQueryHandler : IRequestHandler<GetAllPermissionQuery, ErrorOr<IReadOnlyList<PermissionResponse>>>
    {
        private readonly IPermissionRepository _permissionRepository;
        public GetAllPermissionQueryHandler(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }
        public async Task<ErrorOr<IReadOnlyList<PermissionResponse>>> Handle(GetAllPermissionQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Permission> Permissions = await _permissionRepository.GetAll();
            return Permissions.Select(permission => new PermissionResponse(
               permission.Id.Value,
               permission.Name
              
             )).ToList();
        }
    
    }
}
