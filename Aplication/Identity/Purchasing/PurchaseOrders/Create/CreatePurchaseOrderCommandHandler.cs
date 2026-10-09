using Domain.Entities.Catalogs.Companies;
using Domain.Entities.Catalogs.Products.Products;
using Domain.Entities.Purchasing.PurchaseOrders;
using Domain.Primitives;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Purchasing.PurchaseOrders.Create
{
    internal sealed class CreatePurchaseOrderCommandHandler : IRequestHandler<CreatePurchaseOrderCommand, ErrorOr<Unit>>
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePurchaseOrderCommandHandler(IPurchaseOrderRepository purchaseOrderRepository, IUnitOfWork unitOfWork)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Unit>> Handle(CreatePurchaseOrderCommand request, CancellationToken cancellationToken)
        {
            // 1. Validaciones en Application
            if (await _purchaseOrderRepository.ExistsByOrderNumber(request.OrderNumber))
            {
                return Error.Conflict("PurchaseOrder.DuplicateNumber", $"Ya existe una orden con el número '{request.OrderNumber}'.");
            }

            // 2. Instanciación en el Domain
            var orderId = new PurchaseOrderId(Guid.NewGuid());
            var purchaseOrder = new PurchaseOrder(
                orderId,
                new CompanyId(request.CompanyId),
                request.OrderNumber,
                request.OrderDate);

            foreach (var item in request.Details)
            {
                purchaseOrder.AddDetail(
                    new ProductId(item.ProductId),
                    item.Quantity,
                    item.UnitPrice);
            }

            _purchaseOrderRepository.Add(purchaseOrder);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}