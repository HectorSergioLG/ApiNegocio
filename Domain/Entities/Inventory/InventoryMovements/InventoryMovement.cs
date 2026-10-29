using Domain.Entities.Catalogs.Companies;
using Domain.Entities.Catalogs.Products.Products;
using Domain.Primitives;

namespace Domain.Entities.Inventory.InventoryMovements
{
    public sealed class InventoryMovement : AggregateRoot
    {
        public InventoryMovementId Id { get; private set; }
        public CompanyId CompanyId { get; private set; }
        public Guid WarehouseId { get; private set; }
        public ProductId ProductId { get; private set; }
        public MovementType Type { get; private set; }
        public decimal Quantity { get; private set; } // Puede ser positivo (entradas) o negativo (salidas)
        public string ReferenceDocument { get; private set; } = string.Empty; // Ej: ID de orden de compra, ID de ajuste
        public DateTime MovementDate { get; private set; }
        public Guid CreatedBy { get; private set; } // Usuario que generó el movimiento


        private InventoryMovement() { }

        public InventoryMovement(  InventoryMovementId id, CompanyId companyId, Guid warehouseId, ProductId productId,  MovementType type, decimal quantity, string referenceDocument, DateTime movementDate, Guid createdBy)
        {
            Id = id;
            CompanyId = companyId;
            WarehouseId = warehouseId;
            ProductId = productId;
            Type = type;
            Quantity = quantity;
            ReferenceDocument = referenceDocument;
            MovementDate = movementDate;
            CreatedBy = createdBy;
        }
    }
}
