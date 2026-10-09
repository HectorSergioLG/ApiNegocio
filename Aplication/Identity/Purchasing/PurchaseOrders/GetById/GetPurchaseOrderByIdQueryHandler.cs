using Aplication.Identity.Purchasing.PurchaseOrders.Common;
using Domain.Entities.Purchasing.PurchaseOrders;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Purchasing.PurchaseOrders.GetById
{
    internal sealed class GetPurchaseOrderByIdQueryHandler : IRequestHandler<GetPurchaseOrderByIdQuery, ErrorOr<PurchaseOrderResponse>>
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public GetPurchaseOrderByIdQueryHandler(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository ?? throw new ArgumentNullException(nameof(purchaseOrderRepository));
        }

        public async Task<ErrorOr<PurchaseOrderResponse>> Handle(GetPurchaseOrderByIdQuery request,CancellationToken cancellationToken)
        {
            var order = await _purchaseOrderRepository.GetById( new PurchaseOrderId(request.Id));

            if (order is null)
            {
                return Error.NotFound( code: "PurchaseOrder.NotFound", description: $"La orden de compra con id '{request.Id}' no fue encontrada.");
            }

            return new PurchaseOrderResponse(
                order.Id.Value,
                order.CompanyId.Value,
                order.OrderNumber,
                order.OrderDate,
                order.Status.ToString(),
                order.TotalAmount,
                order.Details.Select(d => new PurchaseOrderDetailResponse(
                    d.Id.Value,
                    d.ProductId.Value,
                    d.Quantity,
                    d.UnitPrice,
                    d.SubTotal)).ToList());
        }
    }
}
