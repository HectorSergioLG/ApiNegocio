using Domain.Entities.Catalogs.Products.Products;
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
            if (request.Price <= 0)
            {
                return Error.Validation("Price.Invalid", "El precio del producto debe ser mayor a cero");
            }
            if (request.Stock < 0)
            {
                return Error.Validation("Stock.Invalid", "El stock del producto no puede ser negativo");
            }

            /*if (UnitsMeasures.Exist()) { 
                
            }
            if (Brands.Exist())
            {
            }*/

            var product = new Product(
                new ProductId(Guid.NewGuid()),
                request.Name,
                new(),
                new(),
                request.Description,
                request.Price,
                request.Stock
            );

            _productRepository.Add(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
