using Domain.Entities.Catalogs.Products.UnitsMesures;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Catalogs
{
    public class UnitMeasureRepository : IUnitMeasureRepository
    {
        private readonly ApplicationDbContext _context;

        public void Add(UnitMeasure unitMesure) => _context.UnitMeasures.AddAsync(unitMesure);

        public void Delete(UnitMeasure unitMesure) => _context.UnitMeasures.Remove(unitMesure);

        public Task<bool> Exists(UnitMeasureId id) => _context.UnitMeasures.AnyAsync(c => c.Id == id);

        public Task<List<UnitMeasure>> GetAll() => _context.UnitMeasures.ToListAsync();

        public Task<UnitMeasure?> GetById(UnitMeasureId id) => _context.UnitMeasures.SingleOrDefaultAsync(c => c.Id == id);

        public void Update(UnitMeasure unitMesure) => _context.UnitMeasures.Update(unitMesure);
    }
}
