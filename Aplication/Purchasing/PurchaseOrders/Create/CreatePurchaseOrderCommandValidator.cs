using FluentValidation;

namespace Aplication.Purchasing.PurchaseOrders.Create
{
    public sealed class CreatePurchaseOrderCommandValidator : AbstractValidator<CreatePurchaseOrderCommand>
    {
        public CreatePurchaseOrderCommandValidator()
        {
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("La empresa es requerida.");
            RuleFor(x => x.OrderNumber).NotEmpty().MaximumLength(50).WithMessage("El número de orden es requerido y no debe exceder 50 caracteres.");
            RuleFor(x => x.OrderDate).NotEmpty().WithMessage("La fecha de la orden es requerida.");
            RuleFor(x => x.Details).NotEmpty().WithMessage("Debe incluir al menos un producto en la orden.");
            RuleForEach(x => x.Details).ChildRules(detail =>
            {
                detail.RuleFor(d => d.ProductId).NotEmpty().WithMessage("El producto es requerido.");
                detail.RuleFor(d => d.Quantity).GreaterThan(0).WithMessage("La cantidad debe ser mayor a 0.");
                detail.RuleFor(d => d.UnitPrice).GreaterThan(0).WithMessage("El precio unitario debe ser mayor a 0.");
            });
        }
    }
}
