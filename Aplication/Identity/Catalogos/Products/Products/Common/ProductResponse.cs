using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogos.Products.Products.Common
{
    public record ProductResponse(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        int Stock
    );
}
