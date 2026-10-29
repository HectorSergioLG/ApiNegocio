using Domain.Entities.Catalogs.Companies;
using Domain.Entities.Catalogs.Products.Products;

namespace Domain.Entities.Inventory.ProductStocks
{
    public interface IProductStockRepository
    {
        Task<ProductStock?> GetByLocationAsync(CompanyId companyId, Guid warehouseId, ProductId productId);
        Task<IReadOnlyList<ProductStock>> GetByProductAsync(ProductId productId);
        void Add(ProductStock productStock);
        void Update(ProductStock productStock);
    }
}
