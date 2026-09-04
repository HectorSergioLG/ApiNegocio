using Aplication.Identity.Catalogos.Customers.Create;
using Aplication.Identity.Catalogos.Customers.Delete;
using Aplication.Identity.Catalogos.Customers.GetAll;
using Aplication.Identity.Catalogos.Customers.GetById;
using Aplication.Identity.Catalogos.Customers.Update;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace ApiNegocio.Controllers
{
    [Route("Clientes")]
    public class ClientesController : ApiController
    {
        private readonly ISender _mediator;

        public ClientesController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() { 
            var clientesResult = await _mediator.Send(new GetAllCustomersQuery());
            return clientesResult.Match(
                clientes => Ok(clientes),
                errors => Problem(errors)
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var clienteResult = await _mediator.Send(new GetCustomerByIdQuery(id));
            return clienteResult.Match(
                cliente => Ok(cliente),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Match(
                clienteId =>Ok(clienteId),
                errors => Problem(errors)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerCommand command)
        {
            if (command.Id!= id)
            {
                List<Error> errors = new List<Error>
                {
                    Error.Validation("Cliente.UpdateInvalidId", "El ID de la solicitud no coincide con el ID de la URL.")
                };
                return Problem(errors);
            }

            var result = await _mediator.Send(command);
            return result.Match(
                clienteId => Ok(clienteId),
                errors => Problem(errors)
            );

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteCustomerCommand(id));
            return result.Match(
                clienteId => Ok(clienteId),
                errors => Problem(errors)
            );
        }


    }
}
