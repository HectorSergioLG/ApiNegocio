using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Security.Roles.Delete
{
    public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleCommandValidator() {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
