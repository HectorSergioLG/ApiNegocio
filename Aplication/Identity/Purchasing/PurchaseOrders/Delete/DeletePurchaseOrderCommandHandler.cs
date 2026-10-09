using Domain.Entities.Purchasing.PurchaseOrders;
using Domain.Entities.Purchasing.PurchaseOrders.Enum;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Purchasing.PurchaseOrders.Delete
{
    public sealed class DeletePurchaseOrderCommandHandler : IRequestHandler<DeletePurchaseOrderCommand, ErrorOr<Unit>>
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePurchaseOrderCommandHandler(
        IPurchaseOrderRepository purchaseOrderRepository,
        IUnitOfWork unitOfWork)
        {
            _purchaseOrderRepository = purchaseOrderRepository ?? throw new ArgumentNullException(nameof(purchaseOrderRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(DeletePurchaseOrderCommand request, CancellationToken cancellationToken)
        {
            var orderId = new PurchaseOrderId(request.Id);
            var order = await _purchaseOrderRepository.GetById(orderId);

            if (order is null)
            {
                return Error.NotFound(
                    code: "PurchaseOrder.NotFound",
                    description: $"La orden de compra con id '{request.Id}' no existe.");
            }

            // Regla: No se permite eliminar si ya fue recibida o procesada
            if (order.Status == PurchaseOrderStatus.PartiallyReceived)
            {
                return Error.Conflict(
                    code: "PurchaseOrder.CannotDeleteReceived",
                    description: "No se puede eliminar una orden de compra que ya ha sido recibida en almacén.");
            }

            // Si está en borrador se elimina físicamente; en otro caso se cancela para trazabilidad
            if (order.Status == PurchaseOrderStatus.Draft)
            {
                _purchaseOrderRepository.Delete(order);
            }
            else
            {
                order.ChangeStatus(PurchaseOrderStatus.Cancelled);
                _purchaseOrderRepository.Update(order);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
