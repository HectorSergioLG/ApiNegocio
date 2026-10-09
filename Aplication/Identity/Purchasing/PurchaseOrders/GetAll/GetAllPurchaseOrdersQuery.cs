using Aplication.Identity.Purchasing.PurchaseOrders.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Purchasing.PurchaseOrders.GetAll
{
    public sealed record GetAllPurchaseOrdersQuery : IRequest<ErrorOr<IReadOnlyList<PurchaseOrderResponse>>>;
}
