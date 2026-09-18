using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Customers.Delete
{
    public record DeleteCustomerCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
   
}
