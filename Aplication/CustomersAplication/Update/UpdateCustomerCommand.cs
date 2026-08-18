using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.CustomersAplication.Update
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
