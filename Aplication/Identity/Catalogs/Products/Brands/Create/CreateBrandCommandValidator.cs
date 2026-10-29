using FluentValidation;

namespace Aplication.Identity.Catalogos.Products.Brands.Create
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre de la marca es requerido.")
                .MaximumLength(150).WithMessage("El nombre no debe exceder 150 caracteres.");  
            
            RuleFor(x => x.WebSite).NotEmpty().MaximumLength(550).WithMessage("El sitio web no debe exceder 500 caracteres.");
        }
    }
}
        