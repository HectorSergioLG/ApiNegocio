using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogos.Products.Brands.Create
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        CreateBrandCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(150); 
            RuleFor(x => x.WebSite).NotEmpty().MaximumLength(550);
        }
    }
}
