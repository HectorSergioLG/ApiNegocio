using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Purchasing.PurchaseOrders.Delete
{
    public class DeletePurchaseOrderCommandValidator : AbstractValidator<DeletePurchaseOrderCommand>
    {
        public DeletePurchaseOrderCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El identificador de la orden es requerido.");
        }
    }
}
