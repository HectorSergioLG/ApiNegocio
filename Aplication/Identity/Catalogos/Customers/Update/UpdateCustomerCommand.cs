using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Customers.Update
{
    public record UpdateCustomerCommand(
        Guid Id,
        string Name,
        string FistLastName,
        string SecondLastName,
        string Email,
        string PhoneNumber,
        bool Active
    ) : IRequest<ErrorOr<Unit>>;
}
