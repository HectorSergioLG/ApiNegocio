using ErrorOr;
using MediatR;

namespace Aplication.Identity.Security.Roles.Delete
{
    public record DeleteRoleCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
 


}
