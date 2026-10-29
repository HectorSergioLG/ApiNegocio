using Aplication.Identity.Catalogos.Products.Products.Common;
using Domain.Entities.Catalogs.Products.Products;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Products.Products.GetAll
{
    public sealed class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQuery, ErrorOr<IReadOnlyList<ProductResponse>>>
    {
        private readonly IProductRepository _productRepository;
        public GetAllProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }
        public async Task<ErrorOr<IReadOnlyList<ProductResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Product> Products = await _productRepository.GetAll();
            return Products.Select(p => new ProductResponse(
                p.Id.Value,
                p.Sku,
                p.Name,
                p.Description,
                p.UnitMeasureId.Value,
                p.BrandId.Value,
                p.Price,
                p.IsActive
             )).ToList();
        }
    }
}
