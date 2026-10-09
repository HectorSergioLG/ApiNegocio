using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Purchasing.PurchaseReceipts.Create
{
    public sealed record ReceiptDetail(
       Guid ProductId,
       decimal Quantity,
       decimal UnitPrice,
       decimal TotalPrice);

    public sealed record CreatePurchaseReceiptCommand(
        Guid CompanyId,
        Guid PurchaseOrderId,
        Guid WarehouseId,
        string ReceiptNumber,
        DateTime ReceiptDate,
        List<ReceiptDetail> Details) : IRequest<ErrorOr<Unit>>;
}
