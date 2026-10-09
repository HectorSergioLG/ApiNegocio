using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogs.Companies.Update;

public sealed record UpdateCompanyCommand(
    Guid Id,
    string Name,
    string TradeName,
    string Email,
    string PhoneNumber,
    bool IsActive) : IRequest<ErrorOr<Unit>>;