using Domain.Entities.Catalogs.Products.Products;
using Domain.Primitives;
using ErrorOr;

namespace Domain.Entities.Inventory.InventoryAdjustments
{
    public sealed class InventoryAdjustment : AggregateRoot
    {
        public InventoryAdjustmentId Id { get; private set; }
        public Guid WarehouseId { get; private set; }
        public ProductId ProductId { get; private set; }
        public decimal AdjustedQuantity { get; private set; } // Puede ser positivo (sobrante) o negativo (merma/robo)
        public string Reason { get; private set; } = string.Empty;
        public DateTime AdjustmentDate { get; private set; }
        public AdjustmentStatus Status { get; private set; }

        private InventoryAdjustment() { }

        public InventoryAdjustment(InventoryAdjustmentId id,Guid warehouseId,ProductId productId,decimal adjustedQuantity,string reason,DateTime adjustmentDate)
        {
            Id = id;
            WarehouseId = warehouseId;
            ProductId = productId;
            AdjustedQuantity = adjustedQuantity;
            Reason = reason;
            AdjustmentDate = adjustmentDate;
            Status = AdjustmentStatus.Draft;
        }

        public ErrorOr<Success> Approve()
        {
            if (Status != AdjustmentStatus.Draft)
                return Error.Conflict("InventoryAdjustment.InvalidStatus", "Solo los ajustes en borrador pueden ser aprobados.");

            Status = AdjustmentStatus.Approved;
            return Result.Success;
        }

        public ErrorOr<Success> Cancel()
        {
            if (Status == AdjustmentStatus.Approved)
                return Error.Conflict("InventoryAdjustment.CannotCancel", "Un ajuste aprobado ya generó movimientos físicos y no puede cancelarse.");

            Status = AdjustmentStatus.Cancelled;
            return Result.Success;
        }

    }
}
