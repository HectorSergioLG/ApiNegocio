using Domain.Entities.Inventory.ProductSerials;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Inventory
{
    public sealed class ProductSerialRepository : IProductSerialRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductSerialRepository(ApplicationDbContext context) => _context = context;

        public async Task<ProductSerial?> GetByIdAsync(ProductSerialId id) =>
            await _context.Set<ProductSerial>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<bool> ExistsSerialNumberAsync(string serialNumber) =>
            await _context.Set<ProductSerial>().AnyAsync(x => x.SerialNumber == serialNumber);

        public void Add(ProductSerial serial) => _context.Set<ProductSerial>().Add(serial);
        public void Update(ProductSerial serial) => _context.Set<ProductSerial>().Update(serial);
    }
}
