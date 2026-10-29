using ApiNegocio.Controllers.Common;
using Aplication.Identity.Catalogos.Products.Brands.Create;
using Aplication.Identity.Catalogos.Products.Brands.Delete;
using Aplication.Identity.Catalogos.Products.Brands.GetAll;
using Aplication.Identity.Catalogos.Products.Brands.Update;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiNegocio.Controllers
{
    [Route("Marca")]
    [ApiController]
    public class BrandsController : ApiController
    {
        private readonly ISender _mediator;

        public BrandsController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBrandCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Match(
                id => CreatedAtAction(nameof(GetById), new { id }, id),
                errors => Problem(errors));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetBrandByIdQuery(id));

            return result.Match(
                brand => Ok(brand),
                errors => Problem(errors));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllBrandsQuery());

            return result.Match(
                brands => Ok(brands),
                errors => Problem(errors));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBrandCommand command)
        {
            if (id != command.Id)
            {
                return Problem(new List<Error>
            {
                Error.Validation("Brand.IdMismatch", "El identificador de la URL no coincide con el cuerpo.")
            });
            }

            var result = await _mediator.Send(command);

            return result.Match(
                _ => NoContent(),
                errors => Problem(errors));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteBrandCommand(id));

            return result.Match(
                _ => NoContent(),
                errors => Problem(errors));
        }
    }
}
