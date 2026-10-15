using FluentValidation;

namespace Aplication.Identity.Catalogos.Products.Brands.Create
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(150); 
            RuleFor(x => x.WebSite).NotEmpty().MaximumLength(550);
        }
    }
}
        