using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Purchasing.PurchaseReceipts.Common
{
    public sealed record PurchaseReceiptResponse(
            Guid Id,
            Guid CompanyId,
            Guid PurchaseOrderId,
            Guid WarehouseId,
            string ReceiptNumber,
            DateTime ReceiptDate,
            IReadOnlyList<PurchaseReceiptDetailResponse> Details
        );
       
    
}
