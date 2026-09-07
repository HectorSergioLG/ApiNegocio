using Domain.Entities.Security.Permissions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Catalogs.Products.Brands
{
    public interface IBrandRepository
    {
        Task<List<Brand>> GetAll();
        Task<Brand?> GetById(BrandId id);
        Task<bool> Exists(BrandId id);
        void Add(Brand brand);
        void Delete(Brand brand);
        void Update(Brand brand);
    }
}
