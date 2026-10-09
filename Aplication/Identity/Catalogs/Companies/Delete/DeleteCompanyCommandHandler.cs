using Domain.Entities.Catalogs.Companies;
using Domain.Primitives;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogs.Companies.Delete
{
    public sealed class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, ErrorOr<Unit>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCompanyCommandHandler(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetById(new CompanyId(request.Id));

            if (company is null)
            {
                return Error.NotFound("Company.NotFound", $"La empresa con Id '{request.Id}' no fue encontrada.");
            }

            _companyRepository.Delete(company);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
