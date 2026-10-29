using Aplication.Inventory.WarehouseLocations.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Inventory.WarehouseLocations.GetById
{
    public sealed record GetWarehouseLocationByIdQuery(Guid Id) : IRequest<ErrorOr<WarehouseLocationResponse>>;
}
