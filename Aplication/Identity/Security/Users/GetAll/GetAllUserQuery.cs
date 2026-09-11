using Aplication.Identity.Security.Users.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Security.Users.GetAll
{
    public record GetAllUserQuery() : IRequest<ErrorOr<IReadOnlyList<UserResponse>>>; 
}
