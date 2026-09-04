
using Domain.Entities.Catalogs.Customer;
using Domain.Entities.Security.Users;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken=default);
    }
}
