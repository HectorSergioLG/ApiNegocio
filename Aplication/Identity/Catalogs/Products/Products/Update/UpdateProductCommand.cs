using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogos.Products.Products.Update
{
    public record UpdateProductCommand(
        Guid Id,
        string Name,
        int IdUnitMeasure,
        int idBrand,
        string Description,
        decimal Price,
        int Stock,
        bool IsActive
    ) : IRequest<ErrorOr<Unit>>;
}
