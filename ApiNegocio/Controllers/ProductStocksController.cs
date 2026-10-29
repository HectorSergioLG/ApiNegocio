using ApiNegocio.Controllers.Common;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
// using Aplication.Inventory.ProductStocks.GetByProduct;
// using Aplication.Inventory.ProductStocks.GetByLocation;

namespace ApiNegocio.Controllers
{
    [Route("product-stocks")]
    public class ProductStocksController : ApiController
    {
        private readonly ISender _mediator;

        public ProductStocksController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("product/{productId:guid}")]
        public async Task<IActionResult> GetByProduct(Guid productId)
        {
            // var result = await _mediator.Send(new GetProductStockByProductQuery(productId));
            // return result.Match(Ok, Problem);
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpGet("location/{warehouseId:guid}/product/{productId:guid}")]
        public async Task<IActionResult> GetByLocation(Guid warehouseId, Guid productId)
        {
            // var result = await _mediator.Send(new GetProductStockByLocationQuery(warehouseId, productId));
            // return result.Match(Ok, Problem);
            return StatusCode(StatusCodes.Status501NotImplemented);
        }
    }
}
