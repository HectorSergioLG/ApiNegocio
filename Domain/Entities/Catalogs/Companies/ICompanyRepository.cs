using Domain.Entities.Catalogs.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Catalogs.Companies
{
    public interface ICompanyRepository
    {
       
        Task<List<Company>> GetAll();

       /*
        Task<Company?> GetById(CompanyId id);

        Task<bool> Exists(CompanyId id);

        void Add(Company Company);

        void Delete(Company Company);

        void Update(Company Company);
       */
    }
}
