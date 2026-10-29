using ErrorOr;
using MediatR;

namespace Aplication.Security.Roles.Create
{
    public record CreateRoleCommand(
        string Name,
        List<string> IdPermissions,
        bool IsActive
    ) : IRequest<ErrorOr<Unit>>;
}
