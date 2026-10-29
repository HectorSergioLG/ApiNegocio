using ApiNegocio.Controllers.Common;
using Aplication.Purchasing.PurchaseOrders.Create;
using Aplication.Purchasing.PurchaseOrders.Delete;
using Aplication.Purchasing.PurchaseOrders.GetAll;
using Aplication.Purchasing.PurchaseOrders.GetById;
using Aplication.Purchasing.PurchaseOrders.Update;
using Aplication.Purchasing.PurchaseReceipts.Create;
using Aplication.Purchasing.PurchaseReceipts.Delete;
using Aplication.Purchasing.PurchaseReceipts.GetAll;
using Aplication.Purchasing.PurchaseReceipts.GetById;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiNegocio.Controllers
{
    //[Route("Purchasing")]
    [Route("Compras")]
    public class PurchasingController : ApiController
    {
        private readonly ISender _mediator;

        public PurchasingController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // --- PURCHASE ORDERS ---

        //[HttpPost("orders")]
        [HttpGet("Ordenes")]
        public async Task<IActionResult> CreateOrder([FromBody] CreatePurchaseOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Match(
                orderId => CreatedAtAction(nameof(GetOrderById), new { id = orderId }, orderId),
                errors => Problem(errors));
        }

        [HttpGet("Ordenes/{id:guid}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var result = await _mediator.Send(new GetPurchaseOrderByIdQuery(id));
            return result.Match(
                order => Ok(order),
                errors => Problem(errors));
        }

        [HttpGet("Ordenes")]
        public async Task<IActionResult> GetAllOrders()
        {
            var result = await _mediator.Send(new GetAllPurchaseOrdersQuery());
            return result.Match(
                orders => Ok(orders),
                errors => Problem(errors));
        }

        [HttpPut("Ordenes/{id:guid}")]
        public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] UpdatePurchaseOrderCommand command)
        {
            if (id != command.Id)
            {
                return Problem(new List<Error>
            {
                Error.Validation("PurchaseOrder.IdMismatch", "El identificador de la ruta no coincide con el cuerpo.")
            });
            }

            var result = await _mediator.Send(command);
            return result.Match(
                _ => NoContent(),
                errors => Problem(errors));
        }

        [HttpDelete("Ordenes/{id:guid}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var result = await _mediator.Send(new DeletePurchaseOrderCommand(id));
            return result.Match(
                _ => NoContent(),
                errors => Problem(errors));
        }

        // --- PURCHASE RECEIPTS ---

        [HttpPost("Recibos")]
        public async Task<IActionResult> CreateReceipt([FromBody] CreatePurchaseReceiptCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Match(
                receiptId => Ok(new { ReceiptId = receiptId }),
                errors => Problem(errors));
        }

        [HttpGet("Recibos/{id:guid}")]
        public async Task<IActionResult> GetReceiptById(Guid id)
        {
            var result = await _mediator.Send(new GetPurchaseReceiptByIdQuery(id));
            return result.Match(
                receipt => Ok(receipt),
                errors => Problem(errors));
        }

        [HttpGet("Recibos")]
        public async Task<IActionResult> GetAllReceipts()
        {
            var result = await _mediator.Send(new GetAllPurchaseReceiptsQuery());
            return result.Match(
                receipts => Ok(receipts),
                errors => Problem(errors));
        }

        [HttpDelete("Recibos/{id:guid}")]
        public async Task<IActionResult> DeleteReceipt(Guid id)
        {
            var result = await _mediator.Send(new DeletePurchaseReceiptCommand(id));
            return result.Match(
                _ => NoContent(),
                errors => Problem(errors));
        }
    }
}
