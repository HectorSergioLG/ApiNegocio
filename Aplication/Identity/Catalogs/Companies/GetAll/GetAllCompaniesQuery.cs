using Aplication.Identity.Catalogos.Companies.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogs.Companies.GetAll
{
    public record GetAllCompaniesQuery() : IRequest<ErrorOr<IReadOnlyList<CompanyResponse>>>;

}
