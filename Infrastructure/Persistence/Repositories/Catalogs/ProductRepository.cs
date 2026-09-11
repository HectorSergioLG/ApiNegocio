using Domain.Entities.Catalogs.Products.Products;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Catalogs
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public void Add(Product product) => _context.Products.AddAsync(product);

        public void Delete(Product product) => _context.Products.Remove(product);

        public Task<bool> Exists(ProductId id) => _context.Products.AnyAsync(p => p.Id == id);

        public Task<List<Product>> GetAll() => _context.Products.ToListAsync();

        public Task<Product?> GetById(ProductId id) => _context.Products.SingleOrDefaultAsync(p => p.Id == id);

        public void Update(Product product) => _context.Products.Update(product);
        }
    }
}
