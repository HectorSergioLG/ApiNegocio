using ErrorOr;
using MediatR;

namespace Aplication.Identity.Purchasing.PurchaseOrders.Delete
{
    public sealed record DeletePurchaseOrderCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
