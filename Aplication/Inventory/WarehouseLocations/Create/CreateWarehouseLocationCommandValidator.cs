using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Inventory.WarehouseLocations.Create
{
    public sealed class CreateWarehouseLocationCommandValidator : AbstractValidator<CreateWarehouseLocationCommand>
    {
        public CreateWarehouseLocationCommandValidator()
        {
            RuleFor(x => x.WarehouseId).NotEmpty().WithMessage("El identificador del almacén es requerido.");
            RuleFor(x => x.Code).NotEmpty().MaximumLength(50).WithMessage("El código es requerido y no debe exceder 50 caracteres.");
            RuleFor(x => x.Description).MaximumLength(200).WithMessage("La descripción no debe exceder 200 caracteres.");
        }
    }
}
