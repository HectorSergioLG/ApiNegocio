using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Purchasing.PurchaseOrders.Common
{
     public sealed record PurchaseOrderResponse(
        Guid Id,
        Guid CompanyId,
        string OrderNumber,
        DateTime OrderDate,
        string Status,
        decimal TotalAmount,
        List<PurchaseOrderDetailResponse> Details);
}
