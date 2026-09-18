using Domain.Entities.Purchasing.PurchaseOrders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Repositories.Purchasing
{
    public sealed class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseOrderRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PurchaseOrder?> GetByIdAsync(PurchaseOrderId id, CancellationToken cancellationToken = default)
        {
            return await _context.PurchaseOrders
                .Include(p => p.Details)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<List<PurchaseOrder>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.PurchaseOrders
                .Include(p => p.Details)
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> ExistsByOrderNumberAsync(string orderNumber, CancellationToken cancellationToken = default)
        {
            return await _context.PurchaseOrders
                .AnyAsync(p => p.OrderNumber == orderNumber, cancellationToken);
        }

        public void Add(PurchaseOrder purchaseOrder) => _context.PurchaseOrders.Add(purchaseOrder);
        public void Update(PurchaseOrder purchaseOrder) => _context.PurchaseOrders.Update(purchaseOrder);
        public void Remove(PurchaseOrder purchaseOrder) => _context.PurchaseOrders.Remove(purchaseOrder);
    }
}
