using Domain.Entities.Catalogs.Products.Brands;
using Domain.Entities.Catalogs.Products.Products;
using Domain.Entities.Catalogs.Products.UnitsMesures;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Products.Products.Create
{
    internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<Unit>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (await _productRepository.ExistsSku(request.Sku))
            {
                return Error.Conflict("Product.DuplicateSku", $"Ya existe un producto registrado con el SKU '{request.Sku}'.");
            }

            var productId = new ProductId(Guid.NewGuid());
            var product = new Product(
                productId,
                request.Sku,
                request.Name,
                request.Description,
                new UnitMeasureId(request.UnitMeasureId),
                new BrandId(request.BrandId),
                request.Price,
                isActive: true);

            _productRepository.Add(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
           
            return Unit.Value;
        }
    }
}
