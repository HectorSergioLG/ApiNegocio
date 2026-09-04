using Aplication.Identity.Catalogos.Customers.Common;
using ErrorOr;
using MediatR;


namespace Aplication.Identity.Catalogos.Customers.GetById
{
    public record GetCustomerByIdQuery(Guid Id) : IRequest<ErrorOr<CustomerResponse>>;

}
