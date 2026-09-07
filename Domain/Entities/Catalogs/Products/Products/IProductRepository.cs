using Domain.Entities.Security.Permissions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Catalogs.Products.Products
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product?> GetById(ProductId id);
        Task<bool> Exists(ProductId id);
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
    }
}
