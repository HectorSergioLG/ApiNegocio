using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Inventory.WarehouseLocations.Create
{
    public sealed record CreateWarehouseLocationCommand(
    Guid WarehouseId,
    string Code,
    string Description) : IRequest<ErrorOr<Unit>>;
}
