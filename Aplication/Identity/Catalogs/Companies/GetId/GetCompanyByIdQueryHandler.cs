using Aplication.Identity.Catalogos.Companies.Common;
using Domain.Entities.Catalogs.Companies;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogs.Companies.GetId
{
    public sealed class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, ErrorOr<CompanyResponse>>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetCompanyByIdQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<ErrorOr<CompanyResponse>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetById(new CompanyId(request.Id));

            if (company is null)
            {
                return Error.NotFound("Company.NotFound", $"La empresa con Id '{request.Id}' no fue encontrada.");
            }

            return new CompanyResponse(
                company.Id.Value,
                company.Name,
                company.TradeName,
                company.Email.Value,
                company.PhoneNumber.Value,
                company.IsActive
            );
        }
    }
}
