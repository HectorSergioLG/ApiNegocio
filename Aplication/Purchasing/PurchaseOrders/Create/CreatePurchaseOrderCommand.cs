using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Purchasing.PurchaseOrders.Create
{
    public sealed record PurchaseOrderDetailDto(
        Guid ProductId,
        decimal Quantity,
        decimal UnitPrice
    );
    public sealed record CreatePurchaseOrderCommand(
        Guid CompanyId,
        string OrderNumber,
        DateTime OrderDate,
        //string Status,
        //decimal TotalAmount,
        List<PurchaseOrderDetailDto> Details
    ) : IRequest<ErrorOr<Unit>>;
}
