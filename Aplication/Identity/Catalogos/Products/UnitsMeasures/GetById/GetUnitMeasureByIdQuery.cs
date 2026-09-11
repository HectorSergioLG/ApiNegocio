using Aplication.Identity.Catalogos.Products.UnitsMeasures.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Products.UnitsMeasures.GetById
{
    public record GetUnitMeasureByIdQuery(Guid Id): IRequest<ErrorOr<UnitMeasureResponse>>;
}
