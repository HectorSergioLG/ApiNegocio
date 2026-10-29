using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Inventory.WarehouseLocations.Delete
{
    public sealed class DeleteWarehouseLocationCommandValidator : AbstractValidator<DeleteWarehouseLocationCommand>
    {
        public DeleteWarehouseLocationCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El identificador de la ubicación es requerido.");
        }
    }
}
