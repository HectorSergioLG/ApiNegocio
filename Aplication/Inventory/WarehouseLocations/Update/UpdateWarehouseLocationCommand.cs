using ErrorOr;
using MediatR;

namespace Aplication.Inventory.WarehouseLocations.Update
{
    public sealed record UpdateWarehouseLocationCommand(
    Guid Id,
    Guid WarehouseId,
    string Code,
    string Description,
    bool IsActive) : IRequest<ErrorOr<Unit>>;
}
