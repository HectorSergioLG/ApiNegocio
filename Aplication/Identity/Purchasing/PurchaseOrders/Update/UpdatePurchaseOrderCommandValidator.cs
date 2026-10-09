using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Purchasing.PurchaseOrders.Update
{
    public sealed class UpdatePurchaseOrderCommandValidator : AbstractValidator<UpdatePurchaseOrderCommand>
    {
        public UpdatePurchaseOrderCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El identificador de la orden de compra es requerido.");

            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("El identificador de la empresa es requerido.");

            RuleFor(x => x.OrderNumber).NotEmpty().MaximumLength(50).WithMessage("El número de orden es requerido y no debe exceder los 50 caracteres.");

            RuleFor(x => x.OrderDate).NotEmpty().WithMessage("La fecha de la orden es requerida.");

            RuleFor(x => x.Details).NotEmpty().WithMessage("La orden de compra debe contener al menos un detalle.");

            RuleForEach(x => x.Details).ChildRules(detail =>
            {
                detail.RuleFor(d => d.ProductId).NotEmpty().WithMessage("El identificador del producto es requerido.");

                detail.RuleFor(d => d.Quantity).GreaterThan(0).WithMessage("La cantidad debe ser mayor a 0.");

                detail.RuleFor(d => d.UnitPrice).GreaterThan(0).WithMessage("El precio unitario debe ser mayor a 0.");
            });

        }
    }
}
