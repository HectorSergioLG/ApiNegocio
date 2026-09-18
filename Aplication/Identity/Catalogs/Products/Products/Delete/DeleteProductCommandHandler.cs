using Domain.Entities.Catalogs.Products.Products;
using Domain.Primitives;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogos.Products.Products.Delete
{
    internal sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ErrorOr<Unit>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if (await _productRepository.GetById(new ProductId(request.Id)) is not Product product)
            {
                return Error.NotFound("Product.NotFound", "El producto no fue encontrado");
            }

            _productRepository.Delete(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    
    }
}
