
using Domain.Entities.Catalogs.Customer;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Customer> Customers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken=default);
    }
}
