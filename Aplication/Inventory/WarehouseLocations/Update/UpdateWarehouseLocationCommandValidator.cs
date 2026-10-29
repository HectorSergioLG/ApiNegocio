using FluentValidation;

namespace Aplication.Inventory.WarehouseLocations.Update
{
    public sealed class UpdateWarehouseLocationCommandValidator : AbstractValidator<UpdateWarehouseLocationCommand> 
    {
        public UpdateWarehouseLocationCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El identificador de la ubicación es requerido.");
            RuleFor(x => x.WarehouseId).NotEmpty().WithMessage("El identificador del almacén es requerido.");
            RuleFor(x => x.Code).NotEmpty().MaximumLength(50).WithMessage("El código es requerido y no debe exceder 50 caracteres.");
            RuleFor(x => x.Description).MaximumLength(200).WithMessage("La descripción no debe exceder 200 caracteres.");
        }
    }
}
