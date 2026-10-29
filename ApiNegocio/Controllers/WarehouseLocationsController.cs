using ApiNegocio.Controllers.Common;
using Aplication.Inventory.WarehouseLocations.Create;
using Aplication.Inventory.WarehouseLocations.Delete;
using Aplication.Inventory.WarehouseLocations.GetAll;
using Aplication.Inventory.WarehouseLocations.GetById;
using Aplication.Inventory.WarehouseLocations.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace ApiNegocio.Controllers
{
    [Route("warehouse-locations")]
    
    public class WarehouseLocationsController : ApiController
    {
        private readonly ISender _mediator;

        public WarehouseLocationsController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]  CreateWarehouseLocationCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Match(id => CreatedAtAction(nameof(GetById), new { id }, id), Problem);
            
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetWarehouseLocationByIdQuery(id));
            return result.Match(Ok, Problem);
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllWarehouseLocationsQuery());
            return result.Match(Ok, Problem);
            
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateWarehouseLocationCommand command)
        {
            // Validación de ID vs Body (como en el estándar)
            var result = await _mediator.Send(command);
            return result.Match(_ => NoContent(), Problem);
            
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteWarehouseLocationCommand(id));
            return result.Match(_ => NoContent(), Problem);
           
        }
    }
}
