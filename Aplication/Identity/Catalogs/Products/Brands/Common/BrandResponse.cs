using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogos.Products.Brands.Common
{
    public record BrandResponse(
        Guid Id,
        string Name,
        string WebSite,
        bool IsActive);
}
