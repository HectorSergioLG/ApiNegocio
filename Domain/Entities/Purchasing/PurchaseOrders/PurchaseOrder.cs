using Domain.Entities.Catalogs.Companies;
using Domain.Entities.Catalogs.Products.Products;
using Domain.Entities.Purchasing.PurchaseOrders.Enum;
using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Purchasing.PurchaseOrders
{
    public class PurchaseOrder: AggregateRoot
    {
        private readonly List<PurchaseOrderDetail> _purchaseOrderDetails = new List<PurchaseOrderDetail>();

        public PurchaseOrderId Id { get; private set; }
        public CompanyId CompanyId { get; private set; }
        public string OrderNumber { get; private set; }
        public DateTime OrderDate { get; private set; }
        public PurchaseOrderStatus Status { get; private set; }
        public decimal TotalAmount => _purchaseOrderDetails.Sum(d => d.SubTotal);
        public IReadOnlyCollection<PurchaseOrderDetail> Details => _purchaseOrderDetails.AsReadOnly();

        public PurchaseOrder() { }

        public PurchaseOrder(PurchaseOrderId id, CompanyId companyId, string orderNumber, DateTime orderDate)
        {
            Id = id;
            CompanyId = companyId;
            OrderNumber = orderNumber;
            OrderDate = orderDate;
            Status = PurchaseOrderStatus.Draft;
        }

        public void AddDetail(PurchaseOrderDetail detail)
        {
            _purchaseOrderDetails.Add(detail);
        }

        public void AddDetail(ProductId productId, decimal quantity, decimal unitPrice)
        {
            var detail = new PurchaseOrderDetail( 
                Id,
                productId, 
                quantity, 
                unitPrice);
            _purchaseOrderDetails.Add(detail);
        }

        public void ChangeStatus(PurchaseOrderStatus newStatus)
        {
            Status = newStatus;
        }

        // Método para actualizar datos de cabecera
        public void UpdateHeader(CompanyId companyId, string orderNumber, DateTime orderDate)
        {
            CompanyId = companyId;
            OrderNumber = orderNumber;
            OrderDate = orderDate;
        }

        // Método para reemplazar los detalles
        public void UpdateDetails(IEnumerable<(ProductId ProductId, decimal Quantity, decimal UnitPrice)> items)
        {
            _purchaseOrderDetails.Clear();
            foreach (var item in items)
            {
                AddDetail(item.ProductId, item.Quantity, item.UnitPrice);
            }
        }

    }
}
