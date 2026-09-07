using Aplication.Identity.Catalogos.Customers.Update;
using Aplication.Identity.Catalogos.Products.Brands.Common;
using Domain.Entities.Catalogs.Products.Brands;
using Domain.Primitives;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogos.Products.Brands.Update
{
    internal sealed class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, ErrorOr<Unit>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBrandCommandHandler(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            if (!await _brandRepository.Exists(new BrandId(request.Id)))
            {
                return Error.NotFound("Marca.NoFound", "La marca no fue encontrada.");
            }

            Brand brand = Brand.UpdateBrand(
                request.Id,
                request.Name,
                request.WebSite,
                request.IsActive
            );
            _brandRepository.Update(brand);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
