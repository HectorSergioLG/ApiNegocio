using Aplication.Identity.Catalogos.Customers.Create;
using ErrorOr;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Aplication.Identity.Security.Users.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator() {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(150).WithName("Nombre"); 
            RuleFor(x => x.FistLastName).MaximumLength(150).WithName("Apellido Paterno");
            RuleFor(x => x.SecondLastName).MaximumLength(150).WithName("Apellido Materno");
            RuleFor(x => x.Email).NotEmpty().MaximumLength(150).WithName("Correo Electrónico");
            RuleFor(x => x.UserName).NotEmpty().WithName("Nombre de usuario");
            RuleFor(x => x.Password).NotEmpty().WithName("Contraseña");
            RuleFor(x => x.IdRoles).NotEmpty().WithName("Lista de Id de roles");


        }
    }
}
