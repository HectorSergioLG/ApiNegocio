using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Inventory.WarehouseLocations.Common
{
    public sealed record WarehouseLocationResponse(
    Guid Id,
    Guid WarehouseId,
    string Code,
    string Description,
    bool IsActive);
}
