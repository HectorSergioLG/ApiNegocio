using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Products.UnitsMeasures.Update
{
    public record UpdateUnitMeasureCommand
    (
        Guid Id,
        string Name,
        string Abbreviation,
        string Description
    ) : IRequest<ErrorOr<Unit>>;
}
