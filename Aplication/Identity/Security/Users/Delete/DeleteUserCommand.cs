using ErrorOr;
using MediatR;

namespace Aplication.Identity.Security.Users.Delete
{
    public record DeleteUserCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
  
}
