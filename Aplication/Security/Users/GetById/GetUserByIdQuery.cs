using Aplication.Security.Users.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Security.Users.GetById
{
    public record  GetUserByIdQuery(Guid Id): IRequest<ErrorOr<UserResponse>>;
}
