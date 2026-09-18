using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Purchasing.PurchaseOrders.Enum
{
    public enum PurchaseOrderStatus
    {
        Draft = 1,// El estado de borrador indica que la orden de compra aún se está creando y todavía no se ha enviado para su aprobación.
        Submitted = 2,// El estado de enviado indica que la orden de compra ha sido enviada para su revisión y aprobación por parte del equipo de compras.
        Approved = 3,// El estado de aprobado indica que la orden de compra ha sido revisada y aprobada por el equipo de compras, y está lista para ser procesada.
        PartiallyReceived = 4,// El estado de parcialmente recibido indica que algunos de los artículos de la orden de compra han sido recibidos, pero aún faltan otros por recibir.
        Completed = 5,// El estado de completado indica que la orden de compra ha sido completamente recibida y procesada.
        Cancelled = 6// El estado de cancelado indica que la orden de compra ha sido cancelada antes de ser procesada.
    }
}
