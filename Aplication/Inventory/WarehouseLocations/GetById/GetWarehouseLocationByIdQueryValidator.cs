using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Inventory.WarehouseLocations.GetById
{
    public sealed class GetWarehouseLocationByIdQueryValidator : AbstractValidator<GetWarehouseLocationByIdQuery>
    {
        public GetWarehouseLocationByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El identificador de la ubicación es requerido.");
        }
    }
}
