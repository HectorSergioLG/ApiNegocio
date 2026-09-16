using Domain.Entities.Catalogs.Companies;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence.Repositories.Catalogs
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        public Task<List<Company>> GetAll() => _context.Companies.ToListAsync();
    }
}
