using Domain.Entities.Catalogs.Products.Brands;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Catalogs
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;
        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Brand brand) => _context.Brands.AddAsync(brand);

        public void Delete(Brand brand) => _context.Brands.Remove(brand);

        public Task<bool> Exists(BrandId id) => _context.Brands.AnyAsync(c => c.Id == id);

        public Task<List<Brand>> GetAll() => _context.Brands.ToListAsync();

        public Task<Brand?> GetById(BrandId id) => _context.Brands.SingleOrDefaultAsync(c => c.Id == id);

        public void Update(Brand brand) => _context.Brands.Update(brand);
    }
}
