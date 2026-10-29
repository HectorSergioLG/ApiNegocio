using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Inventory.InventoryAdjustments.Approve
{
    public sealed class ApproveInventoryAdjustmentCommandValidator : AbstractValidator<ApproveInventoryAdjustmentCommand>
    {
        public ApproveInventoryAdjustmentCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El identificador del ajuste es requerido.");
        }
    }
}
