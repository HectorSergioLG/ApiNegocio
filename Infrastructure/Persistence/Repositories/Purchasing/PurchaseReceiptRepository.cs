using Domain.Entities.Purchasing.PurchaseReceipts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Purchasing
{
    public sealed class PurchaseReceiptRepository : IPurchaseReceiptRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseReceiptRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PurchaseReceipt?> GetById(PurchaseReceiptId id)
        {
            return await _context.PurchaseReceipts
                .Include(p => p.Details)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<bool> ExistsReceiptNumber(string receiptNumber)
        {
            return await _context.PurchaseReceipts
            .AnyAsync(r => r.ReceiptNumber == receiptNumber);
        }
        public void Add(PurchaseReceipt receipt) => _context.PurchaseReceipts.Add(receipt);


    }
}
