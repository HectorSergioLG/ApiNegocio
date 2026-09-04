using Aplication.Identity.Security.Users.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Security.Users.GetById
{
    public record  GetUserByIdQuery(Guid Id): IRequest<ErrorOr<UserResponse>>;
}
