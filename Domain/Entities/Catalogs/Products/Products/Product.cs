using Domain.Entities.Catalogs.Products.Brands;
using Domain.Entities.Catalogs.Products.UnitsMesures;
using Domain.Primitives;

namespace Domain.Entities.Catalogs.Products.Products
{
    public class Product : AggregateRoot
    {
        public Product() { }

        public Product(ProductId productId, string name, UnitMeasure unitMeasure, Brand brand, string description, decimal price, int stock, bool isActive)
        {
            Id = productId;
            Name = name;
            UnitMeasure = unitMeasure;
            UnitMeasureId = unitMeasure.Id;
            Brand = brand;
            BrandId = brand.Id;
            Description = description;
            Price = price;
            Stock = stock;
            IsActive = isActive;
        }

        public ProductId Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        // Propiedades de clave foránea
        public UnitMeasureId UnitMeasureId { get; private set; }
        public BrandId BrandId { get; private set; }

        // Propiedades de navegación
        public UnitMeasure UnitMeasure { get; private set; } 
        public Brand Brand { get; private set; }

        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public bool IsActive { get; private set; }

        public static Product UpdateProduct(Guid id, string name, UnitMeasure unitMeasure, Brand brand, string description, decimal price, int stock, bool isActive)
        {
            return new Product(new ProductId(id),name,unitMeasure, brand, description, price, stock, isActive );
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
