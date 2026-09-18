using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogos.Products.UnitsMeasures.Common
{
    public record UnitMeasureResponse(
        Guid Id,
        string Name,
        string Abbreviation,
        string Description);
}
