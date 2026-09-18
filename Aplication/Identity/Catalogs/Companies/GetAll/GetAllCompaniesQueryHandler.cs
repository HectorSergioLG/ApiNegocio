using Aplication.Identity.Catalogos.Companies.Common;
using Domain.Entities.Catalogs.Companies;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Companies.GetAll
{
    internal class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, ErrorOr<IReadOnlyList<CompanyResponse>>>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetAllCompaniesQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(_companyRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<CompanyResponse>>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Company> companies = await _companyRepository.GetAll();
            return companies.Select(company => new CompanyResponse(
                 company.Id,
                 company.Name,
                 company.IsActive
             )).ToList();
        }
    }
}
