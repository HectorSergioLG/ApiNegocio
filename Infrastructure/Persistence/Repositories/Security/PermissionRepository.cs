using Domain.Entities.Security.Permissions;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Security
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PermissionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<Permission>> GetAll()
        {
            return await _dbContext.Permissions
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Permission?> GetById(PermissionId id)
        {
            return await _dbContext.Permissions
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> Exists(PermissionId id)
        {
            return await _dbContext.Permissions
                .AnyAsync(p => p.Id == id);
        }

        public void Add(Permission role)
        {
            _dbContext.Permissions.Add(role);
        }

        public void Delete(Permission role)
        {
            _dbContext.Permissions.Remove(role);
        }

        public void Update(Permission role)
        {
            _dbContext.Permissions.Update(role);
        }
    }
}
