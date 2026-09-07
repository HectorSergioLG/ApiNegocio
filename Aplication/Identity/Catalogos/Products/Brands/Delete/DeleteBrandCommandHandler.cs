using Domain.Entities.Catalogs.Products.Brands;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Products.Brands.Delete
{
    internal sealed class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, ErrorOr<Unit>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBrandCommandHandler(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
        { 
            _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            if (await _brandRepository.GetById(new BrandId(request.Id)) is not Brand brand)
            {
                return Error.NotFound("Brand", "Brand not found");
            }

            _brandRepository.Delete(brand);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
