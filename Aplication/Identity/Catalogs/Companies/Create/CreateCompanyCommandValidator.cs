using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogs.Companies.Create
{
    public sealed class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100).WithMessage("El nombre es requerido.");
            RuleFor(x => x.TradeName).NotEmpty().MaximumLength(100).WithMessage("El nombre comercial es requerido.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("El email es requerido y debe ser válido.");
            RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(20).WithMessage("El teléfono es requerido.");
        }
    }
}
