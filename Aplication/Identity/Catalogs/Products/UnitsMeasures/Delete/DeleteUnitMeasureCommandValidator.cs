using FluentValidation;

namespace Aplication.Identity.Catalogos.Products.UnitsMeasures.Delete
{
    public class DeleteUnitMeasureCommandValidator : AbstractValidator<DeleteUnitMeasureCommand>
    {
        public DeleteUnitMeasureCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
