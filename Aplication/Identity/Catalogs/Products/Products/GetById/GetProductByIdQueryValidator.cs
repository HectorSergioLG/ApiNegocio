using Aplication.Identity.Catalogos.Products.Products.GetById;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogs.Products.Products.GetById
{
    public sealed class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El identificador del producto es requerido.");
        }
    }
}
