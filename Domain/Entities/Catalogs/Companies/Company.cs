using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Catalogs.Companies
{
    public class Company : AggregateRoot
    {
        public CompanyId Id { get; private set; }
        public string Name { get; private set; }
        public bool IsActive { get; private set; } = true;

        public Company(CompanyId id, string name, bool isActive)
        {
            Id = id;
            Name = name;
            IsActive = isActive;
        }
        public static Company UpdateCompany(Guid id, string name, bool isActive)
        {
            return new Company(new CompanyId(id), name, isActive);
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
