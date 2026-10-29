using FluentValidation;

namespace Aplication.Identity.Catalogos.Products.Products.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Sku)
             .NotEmpty().WithMessage("El SKU es obligatorio.")
             .MaximumLength(50).WithMessage("El SKU no debe exceder 50 caracteres.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre del producto es obligatorio.")
                .MaximumLength(150).WithMessage("El nombre no debe exceder 150 caracteres.");

            RuleFor(x => x.UnitMeasureId)
                .NotEmpty().WithMessage("La unidad de medida es obligatoria.");

            RuleFor(x => x.BrandId)
                .NotEmpty().WithMessage("La marca es obligatoria.");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("El precio debe ser mayor o igual a 0.");
        }
    }
}
