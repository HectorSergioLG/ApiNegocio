using Aplication.Identity.Purchasing.PurchaseReceipts.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Purchasing.PurchaseReceipts.GetById
{
    public sealed record GetPurchaseReceiptByIdQuery(Guid Id) : IRequest<ErrorOr<PurchaseReceiptResponse>>;
}
