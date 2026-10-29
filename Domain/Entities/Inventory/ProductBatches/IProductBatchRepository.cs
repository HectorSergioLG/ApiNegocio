using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Inventory.ProductBatches
{
    public interface IProductBatchRepository
    {
        Task<ProductBatch?> GetById(ProductBatchId id);
        Task<ProductBatch?> GetByBatchNumber(string batchNumber);
        void Add(ProductBatch batch);
        void Update(ProductBatch batch);
    }
}
