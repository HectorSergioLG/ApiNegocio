using Domain.Entities.Catalogs.Products.Products;
using Domain.Entities.Inventory.InventoryMovements;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Inventory
{
    public sealed class InventoryMovementRepository : IInventoryMovementRepository
    {
        private readonly ApplicationDbContext _context;
        public InventoryMovementRepository(ApplicationDbContext context) => _context = context;

        public async Task<InventoryMovement?> GetById(InventoryMovementId id) =>
            await _context.Set<InventoryMovement>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IReadOnlyList<InventoryMovement>> GetByProduct(ProductId productId) =>
            await _context.Set<InventoryMovement>().Where(x => x.ProductId == productId).AsNoTracking().ToListAsync();

        public void Add(InventoryMovement movement) => _context.Set<InventoryMovement>().Add(movement);

    }
}
