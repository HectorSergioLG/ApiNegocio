using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Inventory.WarehouseLocations
{
    public sealed class WarehouseLocation : AggregateRoot
    {
        public WarehouseLocationId Id { get; private set; }
        public Guid WarehouseId { get; private set; } // Referencia al Almacén padre
        public string Code { get; private set; } = string.Empty; // Ej: "A1-B2"
        public string Description { get; private set; } = string.Empty;
        public bool IsActive { get; private set; }

        private WarehouseLocation() { }

        public WarehouseLocation(WarehouseLocationId id, Guid warehouseId, string code, string description, bool isActive = true)
        {
            Id = id;
            WarehouseId = warehouseId;
            Code = code;
            Description = description;
            IsActive = isActive;
        }

        public void Update(string code, string description, bool isActive)
        {
            Code = code;
            Description = description;
            IsActive = isActive;
        }

        public void Deactivate() => IsActive = false;

    }
}
