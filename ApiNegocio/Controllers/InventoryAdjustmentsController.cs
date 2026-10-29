using ApiNegocio.Controllers.Common;
using Aplication.Inventory.InventoryAdjustments.Approve;
using Aplication.Inventory.InventoryAdjustments.Create;
using Aplication.Inventory.InventoryAdjustments.GetAll;
using Aplication.Inventory.InventoryAdjustments.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiNegocio.Controllers
{
    [Route("api/inventory-adjustments")]
    
    public class InventoryAdjustmentsController : ApiController
    {
            private readonly ISender _mediator;

            public InventoryAdjustmentsController(ISender mediator)
            {
                _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            }

            [HttpPost]
            public async Task<IActionResult> Create([FromBody] CreateInventoryAdjustmentCommand command)
            {
                var result = await _mediator.Send(command);

                return result.Match( id => CreatedAtAction(nameof(GetById), new { id }, id), errors => Problem(errors));
            }

            [HttpPost("{id:guid}/approve")]
            public async Task<IActionResult> Approve(Guid id)
            {
                var command = new ApproveInventoryAdjustmentCommand(id);
                var result = await _mediator.Send(command);

                return result.Match( _ => NoContent(), errors => Problem(errors));
            }

            // TODO: Implementar GetInventoryAdjustmentByIdQuery en Application
            [HttpGet("{id:guid}")]
            public async Task<IActionResult> GetById(Guid id)
            {
                var result = await _mediator.Send(new GetInventoryAdjustmentByIdQuery(id));
                return result.Match(Ok, Problem);
            }

            [HttpGet()]
            public async Task<IActionResult> GetByAll()
            {
                var result = await _mediator.Send(new GetAllInventoryAdjustmentsQuery());
                return result.Match(Ok, Problem);
            }
    }
}
