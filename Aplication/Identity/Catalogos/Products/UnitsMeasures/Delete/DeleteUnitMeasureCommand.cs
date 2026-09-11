using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Products.UnitsMeasures.Delete
{
    public record DeleteUnitMeasureCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
   
}
