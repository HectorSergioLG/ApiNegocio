using Domain.Entities.Security.Roles;
using Domain.Primitives;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Aplication.Identity.Security.Roles.Delete
{
    internal sealed class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, ErrorOr<Unit>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRoleCommandHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
        {
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            if (await _roleRepository.GetById(new RoleId(request.Id)) is not Role role)
            {
                return Error.NotFound("Role.NotFound", "El rol no fue encontrado.");
            }

            _roleRepository.Delete(role);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
