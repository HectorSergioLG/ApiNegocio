using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogos.Products.Brands.Create
{
    public record CreateBrandCommand(
        string Name,
        string WebSite,
        bool IsActive) : IRequest<ErrorOr<Unit>>;
}
