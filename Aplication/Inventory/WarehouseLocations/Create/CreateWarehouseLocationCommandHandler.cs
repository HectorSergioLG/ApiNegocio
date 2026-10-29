using Domain.Entities.Inventory.WarehouseLocations;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Aplication.Inventory.WarehouseLocations.Create
{
    public sealed class CreateWarehouseLocationCommandHandler : IRequestHandler<CreateWarehouseLocationCommand, ErrorOr<Unit>>
    {
        private readonly IWarehouseLocationRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateWarehouseLocationCommandHandler(
            IWarehouseLocationRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateWarehouseLocationCommand request,CancellationToken cancellationToken)
        {
            if (await _repository.ExistsCodeInWarehouse(request.WarehouseId, request.Code))
            {
                return Error.Conflict(
                    "WarehouseLocation.DuplicateCode",
                    $"Ya existe una ubicación con el código '{request.Code}' en este almacén.");
            }

            var locationId = new WarehouseLocationId(Guid.NewGuid());
            var location = new WarehouseLocation(
                locationId,
                request.WarehouseId,
                request.Code,
                request.Description,
                isActive: true);

            _repository.Add(location);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

       
    }
}
