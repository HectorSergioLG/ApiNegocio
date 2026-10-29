using ErrorOr;
using MediatR;

namespace Aplication.Security.Roles.Delete
{
    public record DeleteRoleCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
 


}
