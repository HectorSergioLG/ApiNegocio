using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Inventory.ProductSerials
{
    public interface IProductSerialRepository
    {
        Task<ProductSerial?> GetByIdAsync(ProductSerialId id);
        Task<bool> ExistsSerialNumberAsync(string serialNumber);
        void Add(ProductSerial serial);
        void Update(ProductSerial serial);
    }
}
