using Domain.Entities.Catalogs.Products.Products;

namespace Domain.Entities.Inventory.InventoryMovements
{
    public interface IInventoryMovementRepository
    {
        Task<InventoryMovement?> GetById(InventoryMovementId id);
        Task<IReadOnlyList<InventoryMovement>> GetByProduct(ProductId productId);

        // Solo existe método de adición (Inmutabilidad de movimientos)
        void Add(InventoryMovement movement);
    }
}
