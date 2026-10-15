using Aplication.Identity.Purchasing.PurchaseReceipts.Common;
using Domain.Entities.Purchasing.PurchaseReceipts;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Purchasing.PurchaseReceipts.GetById
{
    internal class GetPurchaseReceiptByIdQueryHandler : IRequestHandler<GetPurchaseReceiptByIdQuery, ErrorOr<PurchaseReceiptResponse>>
    {
        private readonly IPurchaseReceiptRepository _receiptRepository;

        public GetPurchaseReceiptByIdQueryHandler(IPurchaseReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository ?? throw new ArgumentNullException(nameof(receiptRepository));
        }
        public async Task<ErrorOr<PurchaseReceiptResponse>> Handle(GetPurchaseReceiptByIdQuery request,CancellationToken cancellationToken)
        {
            var receipt = await _receiptRepository.GetById(new PurchaseReceiptId(request.Id));

            if (receipt is null)
            {
                return Error.NotFound(
                    code: "PurchaseReceipt.NotFound",
                    description: $"La recepción con id '{request.Id}' no fue encontrada.");
            }

            return new PurchaseReceiptResponse(
                receipt.Id.Value,
                receipt.CompanyId.Value,
                receipt.PurchaseOrderId.Value,
                receipt.WarehouseId,
                receipt.ReceiptNumber,
                receipt.ReceiptDate,
                receipt.Details.Select(d => new PurchaseReceiptDetailResponse(
                    d.Id.Value,
                    d.ProductId.Value,
                    d.ReceivedQuantity,
                    d.UnitCost,
                    d.ReceivedQuantity * d.UnitCost)).ToList());
        }
    }
}
