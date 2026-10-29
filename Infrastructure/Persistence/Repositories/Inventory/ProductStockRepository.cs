using Domain.Entities.Catalogs.Companies;
using Domain.Entities.Catalogs.Products.Products;
using Domain.Entities.Inventory.ProductStocks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Inventory
{
    public sealed class ProductStockRepository : IProductStockRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductStockRepository(ApplicationDbContext context) => _context = context;

        public async Task<ProductStock?> GetByLocationAsync(CompanyId companyId, Guid warehouseId, ProductId productId) =>
            await _context.Set<ProductStock>()
                .FirstOrDefaultAsync(x => x.CompanyId == companyId && x.WarehouseId == warehouseId && x.ProductId == productId);

        public async Task<IReadOnlyList<ProductStock>> GetByProductAsync(ProductId productId) =>
            await _context.Set<ProductStock>().Where(x => x.ProductId == productId).AsNoTracking().ToListAsync();

        public void Add(ProductStock productStock) => _context.Set<ProductStock>().Add(productStock);
        public void Update(ProductStock productStock) => _context.Set<ProductStock>().Update(productStock);
    }
}
