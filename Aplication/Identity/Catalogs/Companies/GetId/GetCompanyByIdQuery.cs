using Aplication.Identity.Catalogos.Companies.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogs.Companies.GetId
{
    public sealed record GetCompanyByIdQuery(Guid Id) : IRequest<ErrorOr<CompanyResponse>>;
}
