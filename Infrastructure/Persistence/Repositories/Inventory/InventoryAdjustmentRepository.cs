using Domain.Entities.Inventory.InventoryAdjustments;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Inventory
{
    public sealed class InventoryAdjustmentRepository : IInventoryAdjustmentRepository
    {
        private readonly ApplicationDbContext _context;
        public InventoryAdjustmentRepository(ApplicationDbContext context) => _context = context;

        public async Task<InventoryAdjustment?> GetById(InventoryAdjustmentId id) =>
            await _context.Set<InventoryAdjustment>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IReadOnlyList<InventoryAdjustment>> GetAll() =>
            await _context.Set<InventoryAdjustment>().AsNoTracking().ToListAsync();

        public void Add(InventoryAdjustment adjustment) => _context.Set<InventoryAdjustment>().Add(adjustment);
        public void Update(InventoryAdjustment adjustment) => _context.Set<InventoryAdjustment>().Update(adjustment);
    }

}
