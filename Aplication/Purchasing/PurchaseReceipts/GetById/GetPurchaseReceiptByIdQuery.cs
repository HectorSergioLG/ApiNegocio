using Aplication.Purchasing.PurchaseReceipts.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Purchasing.PurchaseReceipts.GetById
{
    public sealed record GetPurchaseReceiptByIdQuery(Guid Id) : IRequest<ErrorOr<PurchaseReceiptResponse>>;
}
