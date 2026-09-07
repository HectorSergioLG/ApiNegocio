using Domain.Entities.Security.Permissions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Catalogs.Products.UnitsMesures
{
    public interface IUnitMeasureRepository
    {
        Task<List<UnitMeasure>> GetAll();
        Task<UnitMeasure?> GetById(UnitMeasureId id);
        Task<bool> Exists(UnitMeasureId id);
        void Add(UnitMeasure unitMesure);
        void Delete(UnitMeasure unitMesure);
        void Update(UnitMeasure unitMesure);
    }
}
