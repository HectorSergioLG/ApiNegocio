using Domain.Entities.Security.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Repositories.Catalogs
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public void Add(User user)=> _context.Users.AddAsync(user);

        public void Delete(User user) => _context.Users.Remove(user);
        public Task<bool> Exists(UserId id)=>_context.Users.AnyAsync(u=>u.Id == id);
        public Task<List<User>> GetAll()=>_context.Users.ToListAsync();

        public async Task<User?> GetById(UserId id)=> await _context.Users.SingleOrDefaultAsync(u=>u.Id == id);

        public void Update(User user) => _context.Users.Update(user);
    }
}
