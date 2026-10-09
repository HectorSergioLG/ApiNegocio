using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogs.Companies.Delete
{
    public sealed record DeleteCompanyCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
