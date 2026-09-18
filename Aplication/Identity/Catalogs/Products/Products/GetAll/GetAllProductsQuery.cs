using Aplication.Identity.Catalogos.Products.Products.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Products.Products.GetAll
{
    public record GetAllProductsQuery() : IRequest<ErrorOr<IReadOnlyList<ProductResponse>>>;
    
}
