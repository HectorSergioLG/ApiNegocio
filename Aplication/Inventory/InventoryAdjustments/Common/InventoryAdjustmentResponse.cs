namespace Aplication.Inventory.InventoryAdjustments.Common
{
    public sealed record InventoryAdjustmentResponse(
        Guid Id,
        Guid WarehouseId,
        Guid ProductId,
        decimal AdjustedQuantity,
        string Reason,
        DateTime AdjustmentDate,
        string Status
    );
}
