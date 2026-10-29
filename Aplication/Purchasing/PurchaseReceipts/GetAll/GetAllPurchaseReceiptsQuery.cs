using Aplication.Purchasing.PurchaseReceipts.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Purchasing.PurchaseReceipts.GetAll
{
    public sealed record GetAllPurchaseReceiptsQuery : IRequest<ErrorOr<IReadOnlyList<PurchaseReceiptResponse>>>;
}
