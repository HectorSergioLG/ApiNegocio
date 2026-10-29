using Domain.Entities.Inventory.WarehouseLocations;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence.Repositories.Inventory
{
    public sealed class WarehouseLocationRepository : IWarehouseLocationRepository
    {
        private readonly ApplicationDbContext _context;
        public WarehouseLocationRepository(ApplicationDbContext context) => _context = context;

        public async Task<WarehouseLocation?> GetById(WarehouseLocationId id) =>
            await _context.Set<WarehouseLocation>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IReadOnlyList<WarehouseLocation>> GetByWarehouseId(Guid warehouseId) =>
            await _context.Set<WarehouseLocation>().Where(x => x.WarehouseId == warehouseId).AsNoTracking().ToListAsync();

        public async Task<bool> ExistsCodeInWarehouse(Guid warehouseId, string code) =>
            await _context.Set<WarehouseLocation>().AnyAsync(x => x.WarehouseId == warehouseId && x.Code == code);

        public void Add(WarehouseLocation location) => _context.Set<WarehouseLocation>().Add(location);
        public void Update(WarehouseLocation location) => _context.Set<WarehouseLocation>().Update(location);
    }
}
