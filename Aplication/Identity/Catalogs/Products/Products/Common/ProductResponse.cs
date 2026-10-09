namespace Aplication.Identity.Catalogos.Products.Products.Common
{
    public record ProductResponse(
        Guid Id,
        string Name,
        Guid IdUnitMeasure,
        Guid idBrand,
        string Description,
        decimal Price,
        int Stock,
        bool IsActive
    );
}
