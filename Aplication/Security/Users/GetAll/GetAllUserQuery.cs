using Aplication.Security.Users.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Security.Users.GetAll
{
    public record GetAllUserQuery() : IRequest<ErrorOr<IReadOnlyList<UserResponse>>>; 
}
