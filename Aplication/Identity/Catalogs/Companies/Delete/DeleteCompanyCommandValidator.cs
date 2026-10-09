using FluentValidation;

namespace Aplication.Identity.Catalogs.Companies.Delete
{
    public sealed class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommand>
    {
        public DeleteCompanyCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El identificador de la empresa es requerido.");
        }
    }
}
