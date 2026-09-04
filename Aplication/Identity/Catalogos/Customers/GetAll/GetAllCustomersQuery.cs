using Aplication.Identity.Catalogos.Customers.Common;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Customers.GetAll
{
    public record GetAllCustomersQuery() : IRequest<ErrorOr<IReadOnlyList<CustomerResponse>>>;
}
