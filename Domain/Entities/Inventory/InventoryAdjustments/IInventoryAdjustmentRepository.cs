using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Inventory.InventoryAdjustments
{
    public interface IInventoryAdjustmentRepository
    {
        Task<InventoryAdjustment?> GetById(InventoryAdjustmentId id);
        Task<IReadOnlyList<InventoryAdjustment>> GetAll();
        void Add(InventoryAdjustment adjustment);
        void Update(InventoryAdjustment adjustment);
    }
}
