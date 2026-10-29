using Aplication.Inventory.InventoryAdjustments.Common;
using Domain.Entities.Inventory.InventoryAdjustments;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Inventory.InventoryAdjustments.GetById
{
    public sealed class GetInventoryAdjustmentByIdQueryHandler : IRequestHandler<GetInventoryAdjustmentByIdQuery, ErrorOr<InventoryAdjustmentResponse>>
    {
        private readonly IInventoryAdjustmentRepository _repository;

        public GetInventoryAdjustmentByIdQueryHandler(IInventoryAdjustmentRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<ErrorOr<InventoryAdjustmentResponse>> Handle(GetInventoryAdjustmentByIdQuery request, CancellationToken cancellationToken)
        {
            var adjustment = await _repository.GetById(new InventoryAdjustmentId(request.Id));

            if (adjustment is null)
            {
                return Error.NotFound(
                    code: "InventoryAdjustment.NotFound",
                    description: $"El ajuste de inventario con id '{request.Id}' no fue encontrado.");
            }

            return new InventoryAdjustmentResponse(
                adjustment.Id.Value,
                adjustment.WarehouseId,
                adjustment.ProductId.Value,
                adjustment.AdjustedQuantity,
                adjustment.Reason,
                adjustment.AdjustmentDate,
                adjustment.Status.ToString());
        }
 
    }
}
