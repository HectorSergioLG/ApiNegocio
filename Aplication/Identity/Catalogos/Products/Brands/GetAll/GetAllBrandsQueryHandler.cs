using Aplication.Identity.Catalogos.Products.Brands.Common;
using Domain.Entities.Catalogs.Products.Brands;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogos.Products.Brands.GetAll
{
    internal class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, ErrorOr<IReadOnlyList<BrandResponse>>>
    {
        private readonly IBrandRepository _brandRepository;
        public GetAllBrandsQueryHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(_brandRepository));
        }
        public async Task<ErrorOr<IReadOnlyList<BrandResponse>>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Brand> brands = await _brandRepository.GetAll();
            return brands.Select(brand => new BrandResponse(
                 brand.Id.Value,
                 brand.Name,
                 brand.WebSite,
                 brand.IsActive
             )).ToList();
        }
    }
}
