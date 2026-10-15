using Aplication.Identity.Purchasing.PurchaseReceipts.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Purchasing.PurchaseReceipts.GetAll
{
    public sealed record GetAllPurchaseReceiptsQuery : IRequest<ErrorOr<IReadOnlyList<PurchaseReceiptResponse>>>;
}
