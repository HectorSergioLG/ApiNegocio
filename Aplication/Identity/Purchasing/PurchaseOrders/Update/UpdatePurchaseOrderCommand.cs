using Aplication.Identity.Purchasing.PurchaseOrders.Create;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Purchasing.PurchaseOrders.Update
{
    public sealed record UpdatePurchaseOrderCommand(
        Guid Id,
        Guid CompanyId,
        string OrderNumber,
        DateTime OrderDate,
        List<PurchaseOrderDetailDto> Details
     ) : IRequest<ErrorOr<Unit>>;
}
