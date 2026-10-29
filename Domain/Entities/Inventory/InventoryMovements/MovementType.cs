namespace Domain.Entities.Inventory.InventoryMovements
{
    public enum MovementType
    {
        PurchaseReceipt = 1,     // Entrada por compra
        SalesDispatch = 2,       // Salida por venta
        AdjustmentIn = 3,        // Entrada por ajuste/sobrante
        AdjustmentOut = 4,       // Salida por ajuste/merma
        ProductionIn = 5,        // Entrada de producto terminado
        ProductionOut = 6        // Salida de materia prima
    }
}
