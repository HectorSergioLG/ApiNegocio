using Aplication.Inventory.InventoryAdjustments.Common;
using Domain.Entities.Inventory.InventoryAdjustments;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Inventory.InventoryAdjustments.GetAll
{
    public sealed  class GetAllInventoryAdjustmentsQueryHandler : IRequestHandler<GetAllInventoryAdjustmentsQuery, ErrorOr<IReadOnlyList<InventoryAdjustmentResponse>>>
    {
        private readonly IInventoryAdjustmentRepository _repository;

        public GetAllInventoryAdjustmentsQueryHandler(IInventoryAdjustmentRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<ErrorOr<IReadOnlyList<InventoryAdjustmentResponse>>> Handle(GetAllInventoryAdjustmentsQuery request, CancellationToken cancellationToken)
        {
            var adjustments = await _repository.GetAll();

            return adjustments.Select(adjustment => new InventoryAdjustmentResponse(
                adjustment.Id.Value,
                adjustment.WarehouseId,
                adjustment.ProductId.Value,
                adjustment.AdjustedQuantity,
                adjustment.Reason,
                adjustment.AdjustmentDate,
                adjustment.Status.ToString())).ToList();
        }
    }
}
