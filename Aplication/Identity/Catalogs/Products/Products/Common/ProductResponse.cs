namespace Aplication.Identity.Catalogos.Products.Products.Common
{
    public record ProductResponse(
        Guid Id,
        string Sku,
        string Name,
        string Description,
        Guid UnitMeasureId,
        Guid BrandId,
        decimal Price,
        bool IsActive
    );
}
