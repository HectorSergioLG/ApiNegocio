
using Domain.Entities.Catalogs.Companies;
using Domain.Entities.Catalogs.Customer;
using Domain.Entities.Catalogs.Products.Brands;
using Domain.Entities.Catalogs.Products.Products;
using Domain.Entities.Catalogs.Products.UnitsMesures;
using Domain.Entities.Purchasing.PurchaseOrders;
using Domain.Entities.Security.Permissions;
using Domain.Entities.Security.Roles;
using Domain.Entities.Security.Users;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Company> Companies { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<UnitMeasure> UnitMeasures { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Permission> Permissions { get; set; }
        DbSet<PurchaseOrder> PurchaseOrders { get; set; } // <-- Nuevo
        DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } // <-- Nuevo
        Task<int> SaveChangesAsync(CancellationToken cancellationToken=default);
    }
}
