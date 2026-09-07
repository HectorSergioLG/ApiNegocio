using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Catalogs.Products.UnitsMesures
{
    public class UnitMeasure : AggregateRoot
    {
        public UnitMeasure(UnitMeasureId id, string name, string abbreviation, string description)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
            Description = description;
        }

        public UnitMeasureId Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Abbreviation { get; private set; } = string.Empty;
        public string Description { get; private set; }

        public UnitMeasure Update(Guid id,string name, string abbreviation, string description) 
        {
            return new UnitMeasure(new UnitMeasureId(id), name, abbreviation, description);
        }


    }
}
