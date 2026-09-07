using Aplication.Identity.Catalogos.Products.Brands.Common;
using Domain.Entities.Catalogs.Products.Brands;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;


    public record GetBrandByIdQuery(Guid Id) : IRequest<ErrorOr<BrandResponse>>;
    
