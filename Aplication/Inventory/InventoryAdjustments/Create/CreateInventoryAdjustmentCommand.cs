using ErrorOr;
using MediatR;

namespace Aplication.Inventory.InventoryAdjustments.Create
{
    public sealed record CreateInventoryAdjustmentCommand(
        Guid WarehouseId,
        Guid ProductId,
        decimal AdjustedQuantity,
        string Reason,
        DateTime AdjustmentDate) : IRequest<ErrorOr<Guid>>;

}
