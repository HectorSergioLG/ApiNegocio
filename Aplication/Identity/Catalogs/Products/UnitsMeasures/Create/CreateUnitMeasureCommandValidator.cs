using FluentValidation;

namespace Aplication.Identity.Catalogos.Products.UnitsMesures.Create
{
    public class CreateUnitMeasureCommandValidator : AbstractValidator<CreateUnitMeasureCommand>
    {
        public CreateUnitMeasureCommandValidator() { 
            RuleFor(x => x.Name).NotEmpty().MaximumLength(150).WithName("Nombre");
            RuleFor(x => x.Abbreviation).NotEmpty().MaximumLength(10).WithName("Abreviatura");
            RuleFor(x => x.Description).MaximumLength(500).WithName("Descripción");
            RuleFor(x => x).Must(x => !string.IsNullOrWhiteSpace(x.Name) || !string.IsNullOrWhiteSpace(x.Abbreviation))
                .WithMessage("Debe proporcionar al menos un valor para 'Nombre' o 'Abreviatura'.");

        }

    }
}
