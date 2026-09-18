using Aplication.Identity.Catalogos.Products.Brands.Common;
using Domain.Entities.Catalogs.Products.Brands;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Products.Brands.Create
{
    internal sealed class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, ErrorOr<Unit>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Unit>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = new Brand(
                new BrandId(Guid.NewGuid()),
                request.Name,
                request.WebSite,
                request.IsActive
            );

            _brandRepository.Add(brand);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
