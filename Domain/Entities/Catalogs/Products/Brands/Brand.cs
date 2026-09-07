using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Catalogs.Products.Brands
{
    public class Brand : AggregateRoot
    {
        public Brand(BrandId id, string name, string webSite, bool isActive)
        {
            Id = id;
            Name = name;
            WebSite = webSite;
            IsActive = isActive;
        }

        public static Brand UpdateBrand(Guid id, string name, string webSite, bool isActive)
        {
            return new Brand(new BrandId(id), name, webSite, isActive);
        }

        public void Disable()
        {
            IsActive = false;
        }

        public void Enable()
        {
            IsActive = true;
        }

        public BrandId Id { get; private set; }
        public string Name { get; private set; }
        public string WebSite { get; private set; } = string.Empty;
        public bool IsActive { get; private set; } = true;
    }
}
