using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Products.Brands.Delete
{
    public record  DeleteBrandCommand (Guid Id) : IRequest<ErrorOr<Unit>>;)
}
