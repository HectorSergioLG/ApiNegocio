using Aplication.Identity.Purchasing.PurchaseOrders.Common;
using Domain.Entities.Purchasing.PurchaseOrders;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Purchasing.PurchaseOrders.GetById
{
    public sealed record GetPurchaseOrderByIdQuery(Guid Id) : IRequest<ErrorOr<PurchaseOrderResponse>>;
}
