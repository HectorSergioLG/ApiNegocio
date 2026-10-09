using Aplication.Identity.Catalogs.Companies.GetAll;
using Aplication.Identity.Catalogs.Companies.GetId;
using Aplication.Identity.Catalogs.Companies.Create;
using Aplication.Identity.Catalogs.Companies.Update;
using Aplication.Identity.Catalogs.Companies.Delete;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;

namespace ApiNegocio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ApiController
    {
        private readonly ISender _mediator;

        public CompaniesController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Crea una nueva empresa.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompanyCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return result.Match(
                companyId => CreatedAtAction(nameof(GetById), new { id = companyId }, new { id = companyId }),
                errors => Problem(errors));
        }

        /// <summary>
        /// Obtiene una empresa por su ID.
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetCompanyByIdQuery(id), cancellationToken);

            return result.Match(
                company => Ok(company),
                errors => Problem(errors));
        }

        /// <summary>
        /// Obtiene la lista completa de empresas.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllCompaniesQuery(), cancellationToken);

            return result.Match(
                companies => Ok(companies),
                errors => Problem(errors));
        }

        /// <summary>
        /// Actualiza los datos de una empresa existente.
        /// </summary>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCompanyCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
            {
                return Problem(new List<Error>
            {
                Error.Validation("Company.IdMismatch", "El identificador de la ruta no coincide con el cuerpo de la petición.")
            });
            }

            var result = await _mediator.Send(command, cancellationToken);

            return result.Match(
                _ => NoContent(),
                errors => Problem(errors));
        }

        /// <summary>
        /// Elimina o desactiva una empresa por su ID.
        /// </summary>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteCompanyCommand(id), cancellationToken);

            return result.Match(
                _ => NoContent(),
                errors => Problem(errors));
        }
    }
}
