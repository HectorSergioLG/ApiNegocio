using Aplication.Purchasing.PurchaseOrders.Common;
using Domain.Entities.Purchasing.PurchaseOrders;
using ErrorOr;
using MediatR;

namespace Aplication.Purchasing.PurchaseOrders.GetAll
{
    internal class GetAllPurchaseOrdersQueryHandler : IRequestHandler<GetAllPurchaseOrdersQuery, ErrorOr<IReadOnlyList<PurchaseOrderResponse>>>
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public GetAllPurchaseOrdersQueryHandler(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository ?? throw new ArgumentNullException(nameof(purchaseOrderRepository));
        }
        public async Task<ErrorOr<IReadOnlyList<PurchaseOrderResponse>>> Handle(GetAllPurchaseOrdersQuery request,CancellationToken cancellationToken)
        {
            var orders = await _purchaseOrderRepository.GetAll();

            var response = orders.Select(order => new PurchaseOrderResponse(            
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
                    d.SubTotal)).ToList()
            )).ToList();

            return response;
        }

    }
}
