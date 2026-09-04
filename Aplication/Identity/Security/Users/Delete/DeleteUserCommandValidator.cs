using FluentValidation;

namespace Aplication.Identity.Security.Users.Delete
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }

    }
}
