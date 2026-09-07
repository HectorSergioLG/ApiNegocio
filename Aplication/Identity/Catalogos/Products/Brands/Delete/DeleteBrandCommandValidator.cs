using FluentValidation;

namespace Aplication.Identity.Catalogos.Products.Brands.Delete
{
    public class DeleteBrandCommandValidator : AbstractValidator<DeleteBrandCommand>
    {
        public DeleteBrandCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
