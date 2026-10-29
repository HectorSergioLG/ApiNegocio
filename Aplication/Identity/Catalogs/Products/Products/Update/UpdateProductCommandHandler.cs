using Domain.Entities.Catalogs.Products.Brands;
using Domain.Entities.Catalogs.Products.Products;
using Domain.Entities.Catalogs.Products.UnitsMesures;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Products.Products.Update
{
    internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ErrorOr<Unit>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(new ProductId(request.Id));

            if (product is null)
            {
                return Error.NotFound("Product.NotFound", $"El producto con ID '{request.Id}' no fue encontrado.");
            }

            if (!string.Equals(product.Sku, request.Sku, StringComparison.OrdinalIgnoreCase))
            {
                if (await _productRepository.ExistsSku(request.Sku))
                {
                    return Error.Conflict("Product.DuplicateSku", $"El SKU '{request.Sku}' ya está asignado a otro producto.");
                }
            }
            
            product.Update(
                request.Sku,
                request.Name,
                request.Description,
                new UnitMeasureId(request.UnitMeasureId),
                new BrandId(request.BrandId),
                request.Price);

            _productRepository.Update(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
