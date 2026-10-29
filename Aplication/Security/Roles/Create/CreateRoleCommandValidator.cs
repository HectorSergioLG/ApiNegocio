using FluentValidation;

namespace Aplication.Security.Roles.Create
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator() {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(150).WithName("Nombre");
            RuleFor(x => x.IdPermissions).NotEmpty().WithName("Lista de Id de permisos");


        }
    }
}
