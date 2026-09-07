using Domain.Entities.Security.Users;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Security
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<User>> GetAll()
        {
            return await _dbContext.Users
                .Include(u => u.Roles)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User?> GetById(UserId id)
        {
            return await _dbContext.Users
                .Include(u => u.Roles)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> Exists(UserId id)
        {
            return await _dbContext.Users
                .AnyAsync(u => u.Id == id);
        }

        public void Add(User usuario)
        {
            _dbContext.Users.Add(usuario);
        }

        public void Delete(User usuario)
        {
            _dbContext.Users.Remove(usuario);
        }

        public void Update(User usuario)
        {
            _dbContext.Users.Update(usuario);
        }
    }
}
