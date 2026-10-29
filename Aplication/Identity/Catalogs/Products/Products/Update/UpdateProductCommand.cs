using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogos.Products.Products.Update
{
    public record UpdateProductCommand(
        Guid Id,
        string Sku,
        string Name,
        string Description,
        Guid UnitMeasureId,
        Guid BrandId,
        decimal Price,
        bool IsActive
    ) : IRequest<ErrorOr<Unit>>;
}
