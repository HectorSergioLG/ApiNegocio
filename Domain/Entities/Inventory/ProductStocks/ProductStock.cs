using Domain.Entities.Catalogs.Companies;
using Domain.Entities.Catalogs.Products.Products;
using Domain.Primitives;
using ErrorOr;

namespace Domain.Entities.Inventory.ProductStocks
{
    public sealed class ProductStock : AggregateRoot
    {
        public ProductStockId Id { get; private set; }
        public CompanyId CompanyId { get; private set; }
        public Guid WarehouseId { get; private set; }
        public ProductId ProductId { get; private set; }
        public decimal PhysicalQuantity { get; private set; }
        public decimal ReservedQuantity { get; private set; }
        public decimal AvailableQuantity => PhysicalQuantity - ReservedQuantity; // Calculado dinámicamente

        private ProductStock() { }

        public ProductStock(
            ProductStockId id,
            CompanyId companyId,
            Guid warehouseId,
            ProductId productId)
        {
            Id = id;
            CompanyId = companyId;
            WarehouseId = warehouseId;
            ProductId = productId;
            PhysicalQuantity = 0;
            ReservedQuantity = 0;
        }

        public ErrorOr<Success> AdjustPhysicalQuantity(decimal quantityChange)
        {
            if (PhysicalQuantity + quantityChange < 0)
            {
                return Error.Conflict(
                    "ProductStock.NegativeStock",
                    "La operación resultaría en un inventario físico negativo, lo cual no está permitido.");
            }

            PhysicalQuantity += quantityChange;
            return Result.Success;
        }

        public ErrorOr<Success> Reserve(decimal quantityToReserve)
        {
            if (quantityToReserve <= 0)
                return Error.Validation("ProductStock.InvalidReserve", "La cantidad a reservar debe ser mayor a cero.");

            if (AvailableQuantity < quantityToReserve)
                return Error.Conflict("ProductStock.InsufficientStock", "No hay suficiente stock disponible para realizar la reserva.");

            ReservedQuantity += quantityToReserve;
            return Result.Success;
        }

        public ErrorOr<Success> ReleaseReservation(decimal quantityToRelease)
        {
            if (ReservedQuantity - quantityToRelease < 0)
                return Error.Conflict("ProductStock.InvalidRelease", "No se puede liberar más cantidad de la que está reservada.");

            ReservedQuantity -= quantityToRelease;
            return Result.Success;
        }

        public ErrorOr<Success> ConsumeReservation(decimal quantityToConsume)
        {
            if (ReservedQuantity < quantityToConsume)
                return Error.Conflict("ProductStock.InvalidConsumption", "La cantidad a consumir supera la reserva actual.");

            // El consumo realiza una salida física y libera la reserva simultáneamente
            PhysicalQuantity -= quantityToConsume;
            ReservedQuantity -= quantityToConsume;

            return Result.Success;
        }
    }
}

