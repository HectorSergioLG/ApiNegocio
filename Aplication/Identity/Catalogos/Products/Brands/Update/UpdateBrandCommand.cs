using Aplication.Identity.Catalogos.Products.Brands.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Products.Brands.Update
{
    public record UpdateBrandCommand(
        Guid Id, 
        string Name, 
        string WebSite, 
        bool IsActive
       ) : IRequest<ErrorOr<BrandResponse>>;
}
