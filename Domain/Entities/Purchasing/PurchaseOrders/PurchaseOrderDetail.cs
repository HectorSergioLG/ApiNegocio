using Domain.Entities.Catalogs.Products.Products;
using Domain.Primitives;

namespace Domain.Entities.Purchasing.PurchaseOrders
{
    public class PurchaseOrderDetail : AggregateRoot
    {
       
        public PurchaseOrderDetailId Id { get; private set; }
        public PurchaseOrderId PurchaseOrderId { get; private set; }
        public ProductId ProductId { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal SubTotal => Quantity * UnitPrice;

        public PurchaseOrderDetail() { }

        internal PurchaseOrderDetail(PurchaseOrderId purchaseOrderId, ProductId productId, decimal quantity, decimal unitPrice)
        {
            Id = new PurchaseOrderDetailId(Guid.NewGuid());
            PurchaseOrderId = purchaseOrderId;
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}

