using Aplication.CustomersAplication.Common;
using ErrorOr;
using MediatR;

namespace Aplication.CustomersAplication.GetAll
{
    public record GetAllCustomerQuery() : IRequest<ErrorOr<IReadOnlyList<CustomerResponse>>>;
}
