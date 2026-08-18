using ErrorOr;
using MediatR;

namespace Aplication.CustomersAplication.Delete
{
    public record DeleteCustomerCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
   
}
