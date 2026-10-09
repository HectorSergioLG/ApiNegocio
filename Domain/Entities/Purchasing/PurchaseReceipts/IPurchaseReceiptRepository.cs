using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Purchasing.PurchaseReceipts
{
    public interface IPurchaseReceiptRepository
    {
        Task<PurchaseReceipt?> GetById(PurchaseReceiptId id);
        Task<bool> ExistsReceiptNumber(string receiptNumber);
        void Add(PurchaseReceipt receipt);
    }
}
