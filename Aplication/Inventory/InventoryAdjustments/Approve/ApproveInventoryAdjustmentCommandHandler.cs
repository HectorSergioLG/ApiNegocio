using Domain.Entities.Inventory.InventoryAdjustments;
using Domain.Primitives;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Inventory.InventoryAdjustments.Approve
{
    internal sealed class ApproveInventoryAdjustmentCommandHandler : IRequestHandler<ApproveInventoryAdjustmentCommand, ErrorOr<Unit>>
    {
        private readonly IInventoryAdjustmentRepository _adjustmentRepository;
        // TODO: Inyectar IInventoryMovementRepository cuando se genere la entidad
        private readonly IUnitOfWork _unitOfWork;

        public ApproveInventoryAdjustmentCommandHandler(IInventoryAdjustmentRepository adjustmentRepository, IUnitOfWork unitOfWork)
        {
            _adjustmentRepository = adjustmentRepository ?? throw new ArgumentNullException(nameof(adjustmentRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle( ApproveInventoryAdjustmentCommand request, CancellationToken cancellationToken)
        {
            var adjustment = await _adjustmentRepository.GetById(new InventoryAdjustmentId(request.Id));

            if (adjustment is null)
            {
                return Error.NotFound(
                    code: "InventoryAdjustment.NotFound",
                    description: $"El ajuste de inventario con id '{request.Id}' no existe.");
            }

            var approvalResult = adjustment.Approve();
            if (approvalResult.IsError)
            {
                return approvalResult.Errors;
            }

            // TODO: Fase de Movimiento Físico
            // Aquí se debe instanciar un 'InventoryMovement' (tipo AdjustmentIn o AdjustmentOut)
            // utilizando los datos del 'adjustment' para impactar el 'ProductStock'.
            // _movementRepository.Add(movement);

            _adjustmentRepository.Update(adjustment);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
