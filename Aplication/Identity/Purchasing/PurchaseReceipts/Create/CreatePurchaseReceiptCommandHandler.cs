using Domain.Entities.Catalogs.Companies;
using Domain.Entities.Catalogs.Products.Products;
using Domain.Entities.Purchasing.PurchaseOrders;
using Domain.Entities.Purchasing.PurchaseOrders.Enum;
using Domain.Entities.Purchasing.PurchaseReceipts;
using Domain.Primitives;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Purchasing.PurchaseReceipts.Create
{
    public sealed class CreatePurchaseReceiptCommandHandler : IRequestHandler<CreatePurchaseReceiptCommand, ErrorOr<Unit>>
    {
        private readonly IPurchaseOrderRepository _orderRepository;
        private readonly IPurchaseReceiptRepository _receiptRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePurchaseReceiptCommandHandler(IPurchaseOrderRepository orderRepository, IPurchaseReceiptRepository receiptRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _receiptRepository = receiptRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Unit>> Handle(CreatePurchaseReceiptCommand request, CancellationToken cancellationToken)
        {
            // 1. Validar que la orden de compra exista
            var order = await _orderRepository.GetById(new PurchaseOrderId(request.PurchaseOrderId));
            if (order is null)
            {
                return Error.NotFound("PurchaseOrder.NotFound", "La orden de compra especificada no existe.");
            }

            // 2. Validar que no esté ya recibida ni cancelada
            if (order.Status == PurchaseOrderStatus.Approved || order.Status == PurchaseOrderStatus.Cancelled)
            {
                return Error.Conflict("PurchaseOrder.InvalidStatus", $"No se puede recibir una orden en estado {order.Status}.");
            }

            // 3. Validar unicidad del número de recepción
            if (await _receiptRepository.ExistsReceiptNumber(request.ReceiptNumber))
            {
                return Error.Conflict("PurchaseReceipt.DuplicateNumber", $"Ya existe una recepción con el folio '{request.ReceiptNumber}'.");
            }

            // 4. Crear agregado de recepción
            var receiptId = new PurchaseReceiptId(Guid.NewGuid());
            var receipt = new PurchaseReceipt(
                receiptId,
                new CompanyId(request.CompanyId),
                order.Id,
                request.WarehouseId,
                request.ReceiptNumber,
                request.ReceiptDate);

            foreach (var item in request.Details)
            {
                receipt.AddDetail(new ProductId(item.ProductId), item.Quantity, item.UnitPrice);
            }

            // 5. Actualizar estado de la orden de compra a Aprobada
            order.ChangeStatus(PurchaseOrderStatus.Approved);

            _receiptRepository.Add(receipt);
            _orderRepository.Update(order);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
