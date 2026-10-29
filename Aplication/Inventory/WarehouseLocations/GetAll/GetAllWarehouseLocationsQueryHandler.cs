using Aplication.Inventory.WarehouseLocations.Common;
using Domain.Entities.Inventory.WarehouseLocations;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Inventory.WarehouseLocations.GetAll
{
    public sealed class GetAllWarehouseLocationsQueryHandler : IRequestHandler<GetAllWarehouseLocationsQuery, ErrorOr<IReadOnlyList<WarehouseLocationResponse>>>
    {
        private readonly IWarehouseLocationRepository _repository;

        public GetAllWarehouseLocationsQueryHandler(IWarehouseLocationRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<ErrorOr<IReadOnlyList<WarehouseLocationResponse>>> Handle(GetAllWarehouseLocationsQuery request, CancellationToken cancellationToken)
        {
            // NOTA: Requiere que añadas GetAllAsync() a IWarehouseLocationRepository, 
            // o usar GetByWarehouseIdAsync si se pasa el filtro.
            var locations = request.WarehouseId.HasValue
                ? await _repository.GetByWarehouseId(request.WarehouseId.Value)
                : new List<WarehouseLocation>(); // await _repository.GetAllAsync(cancellationToken);

            return locations.Select(l => new WarehouseLocationResponse(
                l.Id.Value,
                l.WarehouseId,
                l.Code,
                l.Description,
                l.IsActive)).ToList();
        }
    }
}
