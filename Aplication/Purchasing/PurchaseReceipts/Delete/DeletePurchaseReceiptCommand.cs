using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Purchasing.PurchaseReceipts.Delete
{
    public sealed record DeletePurchaseReceiptCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
