using Domain.Entities.Catalogs.Products.Products;
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
            if (!await _productRepository.Exists(new ProductId(request.Id)))
            {
                return Error.NotFound("Producto.NoFound", "El producto no fue encontrado.");
            }
            Product product = Product.UpdateProduct(
                request.Id,
                request.Name,
                new(),//request.IdUnitMeasure,
                new(),//request.idBrand,
                request.Description,
                request.Price,
                request.Stock,
                request.IsActive
            );
            _productRepository.Update(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
