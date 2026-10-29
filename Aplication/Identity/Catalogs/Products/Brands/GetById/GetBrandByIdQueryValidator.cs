using FluentValidation;

namespace Aplication.Identity.Catalogs.Products.Brands.GetById
{
    public sealed class GetBrandByIdQueryValidator : AbstractValidator<GetBrandByIdQuery>
    {
        public GetBrandByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El identificador de la marca es requerido.");
        }
    }
}
