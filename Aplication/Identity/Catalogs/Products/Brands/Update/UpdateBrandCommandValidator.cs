using Aplication.Identity.Catalogos.Products.Brands.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogs.Products.Brands.Update
{
    public sealed class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El ID de la marca es obligatorio.");
            RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
            RuleFor(x => x.WebSite).MaximumLength(500);
        }
    }
}
