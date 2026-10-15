using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Purchasing.PurchaseReceipts.GetById
{
    public sealed class GetPurchaseReceiptByIdQueryValidator : AbstractValidator<GetPurchaseReceiptByIdQuery>
    {
        public GetPurchaseReceiptByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El identificador de la recepción es requerido.");
        }
    }
}
