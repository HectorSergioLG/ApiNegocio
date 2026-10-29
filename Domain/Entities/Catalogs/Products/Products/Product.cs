using Domain.Entities.Catalogs.Products.Brands;
using Domain.Entities.Catalogs.Products.UnitsMesures;
using Domain.Primitives;

namespace Domain.Entities.Catalogs.Products.Products
{
    public class Product : AggregateRoot
    {
        public Product() { }
       
        public ProductId? Id { get; private set; }
        public string Sku { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        // Propiedades de clave foránea
        public UnitMeasureId? UnitMeasureId { get; private set; }
        public BrandId? BrandId { get; private set; }

        // Propiedades de navegación
        public UnitMeasure UnitMeasure { get; private set; } 
        public Brand Brand { get; private set; }

       
        public decimal Price { get; private set; }
       
        public bool IsActive { get; private set; }

        public Product(ProductId id, string sku, string name, string description, UnitMeasureId unitMeasureId, BrandId brandId, /*UnitMeasure unitMeasure, Brand brand,*/ decimal price, bool isActive)
        {
            Id = id;
            Sku = sku;
            Name = name;
            Description = description;
            UnitMeasureId = unitMeasureId;
            BrandId = brandId;
            /*UnitMeasure = unitMeasure;
            Brand = brand;*/
            Price = price;
            IsActive = isActive;
        }

        public void Update(string sku, string name, string description, UnitMeasureId unitMeasureId, BrandId brandId, decimal price)
        {
            Sku = sku;
            Name = name;
            Description = description;
            UnitMeasureId = unitMeasureId;
            BrandId = brandId;
            Price = price;
        }   

        public void Disable()
        {
            IsActive = false;
        }

        public void Enable()
        {
            IsActive = true;
        }

    }
}
