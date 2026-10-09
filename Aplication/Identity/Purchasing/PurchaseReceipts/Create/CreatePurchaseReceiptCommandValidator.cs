using FluentValidation;

namespace Aplication.Identity.Purchasing.PurchaseReceipts.Create
{
    internal class CreatePurchaseReceiptCommandValidator : AbstractValidator<CreatePurchaseReceiptCommand>
    {
       public CreatePurchaseReceiptCommandValidator()
        {
           // RuleFor(x => x.CompanyId).NotEmpty();
            RuleFor(x => x.PurchaseOrderId).NotEmpty();
            RuleFor(x => x.WarehouseId).NotEmpty().WithMessage("El almacén de destino es obligatorio.");
            RuleFor(x => x.ReceiptNumber).NotEmpty().MaximumLength(50);
            RuleFor(x => x.ReceiptDate).NotEmpty();
            RuleFor(x => x.Details).NotEmpty().WithMessage("La recepción debe contener al menos un producto.");
            RuleForEach(x => x.Details).ChildRules(d =>
            {
                d.RuleFor(i => i.ProductId).NotEmpty();
                d.RuleFor(i => i.Quantity).GreaterThan(0).WithMessage("La cantidad recibida debe ser mayor a 0.");
                d.RuleFor(i => i.UnitPrice).GreaterThanOrEqualTo(0);
            });
        }
    }
}
