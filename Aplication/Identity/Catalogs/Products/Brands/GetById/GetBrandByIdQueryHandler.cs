using Aplication.Identity.Catalogos.Products.Brands.Common;
using Domain.Entities.Catalogs.Products.Brands;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Products.Brands.GetById
{
    internal sealed class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, ErrorOr<BrandResponse>>
    {
        private readonly IBrandRepository _brandRepository;
        public GetBrandByIdQueryHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
        }
        public async Task<ErrorOr<BrandResponse>> Handle(GetBrandByIdQuery query, CancellationToken cancellationToken)
        {
            if (await _brandRepository.GetById(new BrandId(query.Id)) is not Brand brand)
            {
                return Error.NotFound("Brand.NotFound", "La marca no fue encontrado");
            }
            return new BrandResponse(
                brand.Id.Value,
                brand.Name,
                brand.WebSite,
                brand.IsActive
            );
        }
    }
}