using Domain.Entities.Catalogs.Products.Products;
using Domain.Entities.Inventory.InventoryAdjustments;
using Domain.Primitives;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Inventory.InventoryAdjustments.Create
{
    public sealed class CreateInventoryAdjustmentCommandHandler : IRequestHandler<CreateInventoryAdjustmentCommand, ErrorOr<Guid>>
    {
        private readonly IInventoryAdjustmentRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateInventoryAdjustmentCommandHandler(
        IInventoryAdjustmentRepository repository,
        IUnitOfWork unitOfWork)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Guid>> Handle(CreateInventoryAdjustmentCommand request, CancellationToken cancellationToken)
        {
            var adjustmentId = new InventoryAdjustmentId(Guid.NewGuid());

            var adjustment = new InventoryAdjustment(
                adjustmentId,
                request.WarehouseId,
                new ProductId(request.ProductId),
                request.AdjustedQuantity,
                request.Reason,
                request.AdjustmentDate);

            _repository.Add(adjustment);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return adjustmentId.Value;
        }
    }
}
