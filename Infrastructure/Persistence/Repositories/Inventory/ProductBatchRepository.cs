using Domain.Entities.Inventory.ProductBatches;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Inventory
{
    public sealed class ProductBatchRepository : IProductBatchRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductBatchRepository(ApplicationDbContext context) => _context = context;

        public async Task<ProductBatch?> GetById(ProductBatchId id) =>
            await _context.Set<ProductBatch>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<ProductBatch?> GetByBatchNumber(string batchNumber) =>
            await _context.Set<ProductBatch>().FirstOrDefaultAsync(x => x.BatchNumber == batchNumber);

        public void Add(ProductBatch batch) => _context.Set<ProductBatch>().Add(batch);
        public void Update(ProductBatch batch) => _context.Set<ProductBatch>().Update(batch);
    }
}
