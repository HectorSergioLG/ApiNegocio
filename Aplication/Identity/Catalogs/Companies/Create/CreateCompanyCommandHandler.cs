using Domain.Entities.Catalogs.Companies;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogs.Companies.Create
{
    public sealed class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, ErrorOr<Unit>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            if (PhoneNumber.Create(request.PhoneNumber) is not { } phoneNumber)
            {
                return Error.Validation("PhoneNumber.Invalid", "El número telefónico es inválido.");
            }

            if (Email.Create(request.Email) is not { } email)
            {
                return Error.Validation("Email.Invalid", "El correo electrónico es inválido.");
            }

            var companyId = new CompanyId(Guid.NewGuid());
            var company = new Company(
                companyId,
                request.Name,
                true,
                request.TradeName,
                email,
                phoneNumber
            );

            _companyRepository.Add(company);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit .Value;
        }

        
    }
}
