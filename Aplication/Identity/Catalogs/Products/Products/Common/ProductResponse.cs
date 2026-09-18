namespace Aplication.Identity.Catalogos.Products.Products.Common
{
    public record ProductResponse(
        Guid Id,
        string Name,
        int IdUnitMeasure,
        int idBrand,
        string Description,
        decimal Price,
        int Stock,
        bool IsActive
    );
}
