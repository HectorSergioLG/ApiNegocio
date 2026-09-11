using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogos.Products.UnitsMesures.Create
{
    public record CreateUnitMeasureCommand(
        string Name,
        string Abbreviation,
        string Description) : IRequest<ErrorOr<Unit>>;
}
