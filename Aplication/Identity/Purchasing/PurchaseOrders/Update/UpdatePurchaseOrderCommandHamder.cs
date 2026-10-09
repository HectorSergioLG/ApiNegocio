using Domain.Entities.Catalogs.Companies;
using Domain.Entities.Catalogs.Products.Products;
using Domain.Entities.Purchasing.PurchaseOrders;
using Domain.Entities.Purchasing.PurchaseOrders.Enum;
using Domain.Primitives;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Purchasing.PurchaseOrders.Update
{
    internal sealed class UpdatePurchaseOrderCommandHamder : IRequestHandler<UpdatePurchaseOrderCommand, ErrorOr<Unit>>
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePurchaseOrderCommandHamder(IPurchaseOrderRepository purchaseOrderRepository,IUnitOfWork unitOfWork)
        {
            _purchaseOrderRepository = purchaseOrderRepository ?? throw new ArgumentNullException(nameof(purchaseOrderRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Unit>> Handle(UpdatePurchaseOrderCommand request, CancellationToken cancellationToken)
        {
            // 1. Verificar existencia de la orden
            var orderId = new PurchaseOrderId(request.Id);
            var purchaseOrder = await _purchaseOrderRepository.GetById(orderId);

            if (purchaseOrder is null)
            {
                return Error.NotFound(
                    code: "PurchaseOrder.NotFound",
                    description: $"La orden de compra con el Id '{request.Id}' no fue encontrada.");
            }

            // 2. Regla de estado: Solo se puede modificar en estado Draft
            if (purchaseOrder.Status != PurchaseOrderStatus.Draft)
            {
                return Error.Validation(
                    code: "PurchaseOrder.CannotModify",
                    description: $"No se puede modificar una orden en estado '{purchaseOrder.Status}'. Solo se permiten modificaciones en estado Draft.");
            }

            // 3. Regla de unicidad del número de orden si fue modificado
            if (!string.Equals(purchaseOrder.OrderNumber, request.OrderNumber, StringComparison.OrdinalIgnoreCase))
            {
                if (await _purchaseOrderRepository.ExistsByOrderNumber(request.OrderNumber))
                {
                    return Error.Conflict(
                        code: "PurchaseOrder.DuplicateNumber",
                        description: $"Ya existe otra orden con el número '{request.OrderNumber}'.");
                }
            }

            // 4. Actualizar encabezado
            purchaseOrder.UpdateHeader(
                new CompanyId(request.CompanyId),
                request.OrderNumber,
                request.OrderDate);

            // 5. Actualizar detalles
            var newDetails = request.Details.Select(d => (
                ProductId: new ProductId(d.ProductId),
                d.Quantity,
                d.UnitPrice
            ));

            purchaseOrder.UpdateDetails(newDetails);

            _purchaseOrderRepository.Update(purchaseOrder);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
