using Domain.Entities.Security.Roles;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Security
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RoleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<Role>> GetAll()
        {
            return await _dbContext.Roles
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Role?> GetById(RoleId id)
        {
            return await _dbContext.Roles
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<bool> Exists(RoleId id)
        {
            return await _dbContext.Roles
                .AnyAsync(r => r.Id == id);
        }

        public void Add(Role role)
        {
            _dbContext.Roles.Add(role);
        }

        public void Delete(Role role)
        {
            _dbContext.Roles.Remove(role);
        }

        public void Update(Role role)
        {
            _dbContext.Roles.Update(role);
        }
    }
}
