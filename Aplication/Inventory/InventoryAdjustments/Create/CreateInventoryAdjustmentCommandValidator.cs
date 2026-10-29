using FluentValidation;

namespace Aplication.Inventory.InventoryAdjustments.Create
{
    public sealed class CreateInventoryAdjustmentCommandValidator : AbstractValidator<CreateInventoryAdjustmentCommand>
    {
        public CreateInventoryAdjustmentCommandValidator()
        {
            RuleFor(x => x.WarehouseId).NotEmpty().WithMessage("El almacén es obligatorio.");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("El producto es obligatorio.");
            RuleFor(x => x.AdjustedQuantity).NotEqual(0).WithMessage("La cantidad ajustada no puede ser cero.");
            RuleFor(x => x.Reason).NotEmpty().MaximumLength(200).WithMessage("El motivo es obligatorio y no debe exceder 200 caracteres.");
            RuleFor(x => x.AdjustmentDate).NotEmpty().WithMessage("La fecha de ajuste es obligatoria.");
        }
    }
}
