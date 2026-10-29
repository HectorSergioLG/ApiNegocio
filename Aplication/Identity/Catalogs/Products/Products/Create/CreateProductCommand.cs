using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Products.Products.Create
{
    public record CreateProductCommand(
        string Sku,
        string Name,
        string Description,
        Guid UnitMeasureId,
        Guid BrandId,
        decimal Price
    ) : IRequest<ErrorOr<Unit>>;
}
