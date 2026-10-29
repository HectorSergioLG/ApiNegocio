using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Purchasing.PurchaseReceipts.Common
{
    public sealed record PurchaseReceiptDetailResponse(
    Guid Id,
    Guid ProductId,
    decimal ReceivedQuantity,
    decimal UnitCost,
    decimal TotalCost);
}
