using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Security.Permissions.Create
{
    public class CreatePermissionCommandValidator : AbstractValidator<CreatePermissionCommand>
    {
        public CreatePermissionCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre del permiso no puede estar vacío");
        }
    }
}
