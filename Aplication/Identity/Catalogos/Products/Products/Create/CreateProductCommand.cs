using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Products.Products.Create
{
    public record CreateProductCommand(
        string Name,
        string IdBrand,
        string IdUnitMeasure,
        string Description,
        decimal Price,
        int Stock
    ) : IRequest<ErrorOr<Unit>>;
}
