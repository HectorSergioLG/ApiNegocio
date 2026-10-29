using ErrorOr;
using MediatR;

namespace Aplication.Inventory.WarehouseLocations.Delete
{
    public sealed record DeleteWarehouseLocationCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
