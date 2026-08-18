using Domain.Entities.Catalogs.Customer;
using ErrorOr;
using MediatR;


namespace Aplication.CustomersAplication.GetById
{
    public record GetCustomerByIdQuery(Guid Id): IRequest<ErrorOr<Customer>>;

}
