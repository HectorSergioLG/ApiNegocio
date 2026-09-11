using Aplication.Identity.Catalogos.Products.Products.Common;
using Domain.Entities.Catalogs.Products.Products;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogos.Products.Products.GetById
{
    public record GetProductByIdQuery(Guid Id) : IRequest<ErrorOr<ProductResponse>>;

}
