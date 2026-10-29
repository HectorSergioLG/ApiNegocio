using Aplication.Inventory.WarehouseLocations.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Inventory.WarehouseLocations.GetAll
{
    public sealed record GetAllWarehouseLocationsQuery(Guid? WarehouseId = null) : IRequest<ErrorOr<IReadOnlyList<WarehouseLocationResponse>>>;
}
