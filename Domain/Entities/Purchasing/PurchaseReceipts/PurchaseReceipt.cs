using Domain.Entities.Catalogs.Companies;
using Domain.Entities.Catalogs.Products.Products;
using Domain.Entities.Purchasing.PurchaseOrders;
using Domain.Primitives;

namespace Domain.Entities.Purchasing.PurchaseReceipts
{
    public sealed class PurchaseReceipt : AggregateRoot
    {
        private readonly List<PurchaseReceiptDetail> _details = new();

        public PurchaseReceiptId Id { get; private set; }
        public CompanyId CompanyId { get; private set; }
        public PurchaseOrderId PurchaseOrderId { get; private set; }
        public Guid WarehouseId { get; private set; } // Vinculado a almacén en Inventory
        public string ReceiptNumber { get; private set; }
        public DateTime ReceiptDate { get; private set; }
        public IReadOnlyCollection<PurchaseReceiptDetail> Details => _details.AsReadOnly();

        private PurchaseReceipt() { }

        public PurchaseReceipt( PurchaseReceiptId id, CompanyId companyId, PurchaseOrderId purchaseOrderId,  Guid warehouseId, string receiptNumber, DateTime receiptDate)
        {
            Id = id;
            CompanyId = companyId;
            PurchaseOrderId = purchaseOrderId;
            WarehouseId = warehouseId;
            ReceiptNumber = receiptNumber;
            ReceiptDate = receiptDate;
        }

        public void AddDetail(ProductId productId, decimal quantity, decimal unitCost)
        {
            _details.Add(new PurchaseReceiptDetail(
                new PurchaseReceiptDetailId(Guid.NewGuid()),
                Id,
                productId,
                quantity,
                unitCost));
        }
    }
}
