using Aplication.Identity.Catalogos.Products.Brands.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Products.Brands.GetAll
{
    public record GetAllBrandsQuery() : IRequest<ErrorOr<IReadOnlyList<BrandResponse>>>;

}
