using Domain.Entities.Purchasing.PurchaseOrders;
using Domain.Entities.Purchasing.PurchaseOrders.Enum;
using Domain.Entities.Purchasing.PurchaseReceipts;
using Domain.Primitives;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Purchasing.PurchaseReceipts.Delete
{
    public sealed class DeletePurchaseReceiptCommandHandler : IRequestHandler<DeletePurchaseReceiptCommand, ErrorOr<Unit>>
    {
        private readonly IPurchaseReceiptRepository _receiptRepository;
        private readonly IPurchaseOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePurchaseReceiptCommandHandler(IPurchaseReceiptRepository receiptRepository, IPurchaseOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _receiptRepository = receiptRepository ?? throw new ArgumentNullException(nameof(receiptRepository));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(DeletePurchaseReceiptCommand request, CancellationToken cancellationToken)
        {
            var receiptId = new PurchaseReceiptId(request.Id);
            var receipt = await _receiptRepository.GetById(receiptId);

            if (receipt is null)
            {
                return Error.NotFound(
                    code: "PurchaseReceipt.NotFound",
                    description: $"La recepción con id '{request.Id}' no existe.");
            }

            // Si existe la orden vinculada, se revierte su estado para que pueda recibirse nuevamente
            var order = await _orderRepository.GetById(receipt.PurchaseOrderId);
            if (order is not null && order.Status == PurchaseOrderStatus.PartiallyReceived)
            {
                order.ChangeStatus(PurchaseOrderStatus.Approved);
                _orderRepository.Update(order);
            }

            _receiptRepository.Remove(receipt);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
