using ErrorOr;
using MediatR;

namespace Aplication.Inventory.InventoryAdjustments.Approve
{
    public sealed record ApproveInventoryAdjustmentCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
