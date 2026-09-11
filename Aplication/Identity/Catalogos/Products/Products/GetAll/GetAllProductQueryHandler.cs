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
            _productRepository = productRepository;
        }
        public async Task<ErrorOr<IReadOnlyList<ProductResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Product> Products = await _productRepository.GetAll();
            return Products.Select(product => new ProductResponse(
               product.Id.Value,
               product.Name,
               product.Description,
               product.Price,
               product.Stock,
               product.IsActive
             )).ToList();
        }
    }
}
