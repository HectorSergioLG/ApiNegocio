using Domain.Entities.Inventory.WarehouseLocations;
using Domain.Primitives;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Inventory.WarehouseLocations.Update
{
    internal class UpdateWarehouseLocationCommandHandler : IRequestHandler<UpdateWarehouseLocationCommand, ErrorOr<Unit>>
    {
        private readonly IWarehouseLocationRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateWarehouseLocationCommandHandler(IWarehouseLocationRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateWarehouseLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _repository.GetById(new WarehouseLocationId(request.Id));

            if (location is null)
            {
                return Error.NotFound("WarehouseLocation.NotFound", $"La ubicación con id '{request.Id}' no existe.");
            }

            // Si el código cambia, validar que no exista ya en el mismo almacén
            if (location.Code != request.Code)
            {
                if (await _repository.ExistsCodeInWarehouse(request.WarehouseId, request.Code))
                {
                    return Error.Conflict(
                        "WarehouseLocation.DuplicateCode",
                        $"Ya existe una ubicación con el código '{request.Code}' en este almacén.");
                }
            }

            location.Update(request.Code, request.Description, request.IsActive);

            _repository.Update(location);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}