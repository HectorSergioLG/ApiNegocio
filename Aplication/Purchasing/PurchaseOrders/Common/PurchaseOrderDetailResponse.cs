using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Purchasing.PurchaseOrders.Common
{
    public sealed record PurchaseOrderDetailResponse(
        Guid Id,
        Guid ProductId,
        decimal Quantity,
        decimal UnitPrice,
        decimal TotalPrice
        );
}
