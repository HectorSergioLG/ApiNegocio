using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Inventory.WarehouseLocations
{
    public interface IWarehouseLocationRepository
    {
        Task<WarehouseLocation?> GetById(WarehouseLocationId id);
        Task<IReadOnlyList<WarehouseLocation>> GetByWarehouseId(Guid warehouseId);
        Task<bool> ExistsCodeInWarehouse(Guid warehouseId, string code);
        void Add(WarehouseLocation location);
        void Update(WarehouseLocation location);
    }
}
