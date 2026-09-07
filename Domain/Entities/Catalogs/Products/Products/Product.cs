using Domain.Entities.Catalogs.Products.Brands;
using Domain.Entities.Catalogs.Products.UnitsMesures;
using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace Domain.Entities.Catalogs.Products.Products
{
    public class Product : AggregateRoot
    {
        public Product(ProductId productId, string name, UnitMeasure unitMeasure, Brand brand, string description, decimal price, int stock)
        {
            ProductId = productId;
            Name = name;
            UnitMeasure = unitMeasure;
            Brand = brand;
            Description = description;
            Price = price;
            Stock = stock;
        }

        public ProductId ProductId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public UnitMeasure UnitMeasure { get; private set; } 
        public Brand Brand { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

    }
}
