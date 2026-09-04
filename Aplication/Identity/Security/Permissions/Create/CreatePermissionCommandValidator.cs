using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Security.Permissions.Create
{
    public class CreatePermissionCommandValidator : AbstractValidator<CreatePermissionCommand>
    {
        public CreatePermissionCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre del permiso no puede estar vacío");
        }
    }
}
