using ErrorOr;
using MediatR;

namespace Aplication.Identity.Security.Users.Create
{
    public record CreateUserCommand(
        string Name,
        string FistLastName,
        string SecondLastName,
        List<string> IdRoles,
        string Email,
        string UserName,
        string Password,
        string RegistrationDate,
        bool Active
    ) : IRequest<ErrorOr<Unit>>;
}

           
