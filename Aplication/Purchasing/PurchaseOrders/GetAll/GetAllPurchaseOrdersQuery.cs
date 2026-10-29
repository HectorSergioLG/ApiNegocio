using Aplication.Purchasing.PurchaseOrders.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Purchasing.PurchaseOrders.GetAll
{
    public sealed record GetAllPurchaseOrdersQuery : IRequest<ErrorOr<IReadOnlyList<PurchaseOrderResponse>>>;
}
