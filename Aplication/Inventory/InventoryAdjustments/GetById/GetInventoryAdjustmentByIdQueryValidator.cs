using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Inventory.InventoryAdjustments.GetById
{
    public sealed class GetInventoryAdjustmentByIdQueryValidator : AbstractValidator<GetInventoryAdjustmentByIdQuery>
    {
        public GetInventoryAdjustmentByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El identificador del ajuste de inventario es requerido.");
        }
    }
}
