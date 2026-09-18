using Domain.Entities.Catalogs.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Purchasing.PurchaseOrders
{
    public interface IPurchaseOrderRepository
    {
        Task<List<PurchaseOrder>> GetAll();
        Task<PurchaseOrder?> GetById(PurchaseOrderId id);
        Task<bool> Exists(PurchaseOrderId id);
        void Add(PurchaseOrder purchaseOrder);
        void Delete(PurchaseOrder purchaseOrder);
        void Update(PurchaseOrder purchaseOrder);
    }
}
