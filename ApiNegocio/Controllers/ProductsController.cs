using ApiNegocio.Controllers.Common;
using Aplication.Identity.Catalogos.Products.Products.Create;
using Aplication.Identity.Catalogos.Products.Products.Delete;
using Aplication.Identity.Catalogos.Products.Products.GetAll;
using Aplication.Identity.Catalogos.Products.Products.GetById;
using Aplication.Identity.Catalogos.Products.Products.Update;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiNegocio.Controllers
{
    [Route("Productos")]
   public class ProductsController : ApiController
    {
        private readonly ISender _mediator;

        public ProductsController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Match(
                id => CreatedAtAction(nameof(GetById), new { id }, id),
                errors => Problem(errors));


        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));

            return result.Match(
                product => Ok(product),
                errors => Problem(errors));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());

            return result.Match(
                products => Ok(products),
                errors => Problem(errors));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return Problem(new List<Error>
            {
                Error.Validation("Product.IdMismatch", "El identificador de la URL no coincide con el cuerpo.")
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
            var result = await _mediator.Send(new DeleteProductCommand(id));

            return result.Match(
                _ => NoContent(),
                errors => Problem(errors));
        }
    }
}
