using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Products.Products.Delete
{
    public record DeleteProductCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
