using Domain.Entities.Catalogs.Products.Products;
using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Inventory.ProductBatches
{
    public sealed class ProductBatch : AggregateRoot
    {
        public ProductBatchId Id { get; private set; }
        public ProductId ProductId { get; private set; }
        public string BatchNumber { get; private set; } = string.Empty;
        public DateTime ManufactureDate { get; private set; }
        public DateTime? ExpirationDate { get; private set; }
        public bool IsActive { get; private set; }

        private ProductBatch() { }

        public ProductBatch(ProductBatchId id, ProductId productId, string batchNumber, DateTime manufactureDate, DateTime? expirationDate)
        {
            Id = id;
            ProductId = productId;
            BatchNumber = batchNumber;
            ManufactureDate = manufactureDate;
            ExpirationDate = expirationDate;
            IsActive = true;
        }

        public void UpdateExpiration(DateTime? newExpirationDate)
        {
            ExpirationDate = newExpirationDate;
        }

    }
}
