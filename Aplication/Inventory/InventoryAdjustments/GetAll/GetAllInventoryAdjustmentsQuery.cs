using Aplication.Inventory.InventoryAdjustments.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Inventory.InventoryAdjustments.GetAll
{
    public sealed record GetAllInventoryAdjustmentsQuery : IRequest<ErrorOr<IReadOnlyList<InventoryAdjustmentResponse>>>;

}
