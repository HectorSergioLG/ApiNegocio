using Domain.Entities.Purchasing.PurchaseOrders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Purchasing
{
    public sealed class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseOrderRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PurchaseOrder?> GetById(PurchaseOrderId id)
        {
            return await _context.PurchaseOrders
                .Include(p => p.Details)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<PurchaseOrder>> GetAll()
        {
            return await _context.PurchaseOrders
                .Include(p => p.Details)
                .ToListAsync();
        }

        public async Task<bool> ExistsByOrderNumber(string orderNumber)
        {
            return await _context.PurchaseOrders
                .AnyAsync(p => p.OrderNumber == orderNumber);
        }

        public void Add(PurchaseOrder purchaseOrder) => _context.PurchaseOrders.Add(purchaseOrder);
        public void Update(PurchaseOrder purchaseOrder) => _context.PurchaseOrders.Update(purchaseOrder);
        public void Delete(PurchaseOrder purchaseOrder) => _context.PurchaseOrders.Remove(purchaseOrder);

        
    }
}
