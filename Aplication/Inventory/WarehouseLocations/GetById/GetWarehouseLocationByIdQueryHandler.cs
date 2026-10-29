using Aplication.Inventory.WarehouseLocations.Common;
using Domain.Entities.Inventory.WarehouseLocations;
using ErrorOr;
using MediatR;

namespace Aplication.Inventory.WarehouseLocations.GetById
{
    public sealed class GetWarehouseLocationByIdQueryHandler : IRequestHandler<GetWarehouseLocationByIdQuery, ErrorOr<WarehouseLocationResponse>>   
    {
        private readonly IWarehouseLocationRepository _repository;

        public GetWarehouseLocationByIdQueryHandler(IWarehouseLocationRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<ErrorOr<WarehouseLocationResponse>> Handle(GetWarehouseLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var location = await _repository.GetById(new WarehouseLocationId(request.Id));

            if (location is null)
            {
                return Error.NotFound("WarehouseLocation.NotFound", $"La ubicación con id '{request.Id}' no existe.");
            }

            return new WarehouseLocationResponse(
                location.Id.Value,
                location.WarehouseId,
                location.Code,
                location.Description,
                location.IsActive);
        }
    }
    
}
