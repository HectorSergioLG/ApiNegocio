using Domain.Entities.Catalogs.Products.Products;

namespace Domain.Entities.Purchasing.PurchaseReceipts
{
    public sealed class PurchaseReceiptDetail
    {
        public PurchaseReceiptDetailId Id { get; private set; }
        public PurchaseReceiptId PurchaseReceiptId { get; private set; }
        public ProductId ProductId { get; private set; }
        public decimal ReceivedQuantity { get; private set; }
        public decimal UnitCost { get; private set; }

        public PurchaseReceiptDetail() { }

        public PurchaseReceiptDetail(PurchaseReceiptDetailId id,PurchaseReceiptId purchaseReceiptId,ProductId productId,decimal receivedQuantity,decimal unitCost)
        {
            Id = id;
            PurchaseReceiptId = purchaseReceiptId;
            ProductId = productId;
            ReceivedQuantity = receivedQuantity;
            UnitCost = unitCost;
        }
    }
}
