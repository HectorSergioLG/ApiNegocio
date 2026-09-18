using Aplication.Identity.Catalogos.Products.Products.Common;
using Domain.Entities.Catalogs.Products.Products;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Products.Products.GetById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ErrorOr<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }
        public async Task<ErrorOr<ProductResponse>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            if (await _productRepository.GetById(new ProductId(query.Id)) is not Product product)
            {
                return Error.NotFound("Product.NoFound", "El producto no fue encontrado.");
            }
            return new ProductResponse(product.Id.Value, product.Name, product.Description, product.Price, product.Stock, product.IsActive);
        }
    }
}
