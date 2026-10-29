using Aplication.Inventory.InventoryAdjustments.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Inventory.InventoryAdjustments.GetById
{
    public sealed record GetInventoryAdjustmentByIdQuery(Guid Id) : IRequest<ErrorOr<InventoryAdjustmentResponse>>;
}
