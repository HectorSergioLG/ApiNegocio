using Aplication.Purchasing.PurchaseReceipts.Common;
using Domain.Entities.Purchasing.PurchaseReceipts;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Purchasing.PurchaseReceipts.GetAll
{
    internal class GetAllPurchaseReceiptsQueryHandler : IRequestHandler<GetAllPurchaseReceiptsQuery, ErrorOr<IReadOnlyList<PurchaseReceiptResponse>>>
    {
        private readonly IPurchaseReceiptRepository _receiptRepository;

        public GetAllPurchaseReceiptsQueryHandler(IPurchaseReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository ?? throw new ArgumentNullException(nameof(receiptRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<PurchaseReceiptResponse>>> Handle( GetAllPurchaseReceiptsQuery request, CancellationToken cancellationToken)
        {
            var receipts = await _receiptRepository.GetAll();

            return receipts.Select(receipt => new PurchaseReceiptResponse(
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
                    d.ReceivedQuantity * d.UnitCost)).ToList()
            )).ToList();
        }
    }
}
