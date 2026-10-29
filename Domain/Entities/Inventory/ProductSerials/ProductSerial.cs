using Domain.Entities.Catalogs.Products.Products;
using Domain.Primitives;

namespace Domain.Entities.Inventory.ProductSerials
{

    public sealed class ProductSerial : AggregateRoot
    {
        public ProductSerialId Id { get; private set; }
        public ProductId ProductId { get; private set; }
        public string SerialNumber { get; private set; } = string.Empty;
        public SerialStatus Status { get; private set; }

        private ProductSerial() { }

        public ProductSerial(ProductSerialId id, ProductId productId, string serialNumber)
        {
            Id = id;
            ProductId = productId;
            SerialNumber = serialNumber;
            Status = SerialStatus.Available;
        }

        public void ChangeStatus(SerialStatus newStatus)
        {
            Status = newStatus;
        }
    }
}

