using Domain.Entities.Inventory.WarehouseLocations;
using Domain.Primitives;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Inventory.WarehouseLocations.Delete
{
    public sealed class DeleteWarehouseLocationCommandHandler : IRequestHandler<DeleteWarehouseLocationCommand, ErrorOr<Unit>>
    {
        private readonly IWarehouseLocationRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteWarehouseLocationCommandHandler(IWarehouseLocationRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle( DeleteWarehouseLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _repository.GetById(new WarehouseLocationId(request.Id));

            if (location is null)
            {
                return Error.NotFound("WarehouseLocation.NotFound", $"La ubicación con id '{request.Id}' no existe.");
            }

            // Utilizando baja lógica según la regla del Dominio (también podrías usar _repository.Remove si es físico)
            location.Deactivate();
            _repository.Update(location);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
