using Aplication.Identity.Catalogos.Products.UnitsMeasures.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Products.UnitsMeasures.GetAll
{
    public record GetAllUnitMeasureQuery() : IRequest<ErrorOr<IReadOnlyList<UnitMeasureResponse>>>;

}
