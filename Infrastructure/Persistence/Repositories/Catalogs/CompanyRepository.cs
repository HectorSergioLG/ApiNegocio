using Domain.Entities.Catalogs.Companies;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence.Repositories.Catalogs
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Company?> GetById(CompanyId id)=> await _context.Companies.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<List<Company>> GetAll()=> await _context.Companies.AsNoTracking().ToListAsync();

        public void Add(Company company)=>_context.Companies.Add(company);

        public void Update(Company company)=>_context.Companies.Update(company);

        public void Delete(Company company)=>_context.Companies.Remove(company);

        public async Task<bool> Exists(CompanyId id)=> await _context.Companies.AnyAsync(c => c.Id == id);       
    }
}
