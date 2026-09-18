using Aplication.Identity.Catalogos.Customers.Common;
using Domain.Entities.Catalogs.Customer;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Customers.GetAll
{
   
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, ErrorOr<IReadOnlyList<CustomerResponse>>>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(_customerRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<CustomerResponse>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Customer> customers = await _customerRepository.GetAll();

            return customers.Select(customer => new CustomerResponse(
                 customer.Id.Value,
                 customer.Name,
                 customer.FistLastName,
                 customer.SecondLastName,
                 customer.Email.Value,
                 customer.PhoneNumber.Value,
                 customer.IsActive
             )).ToList();
        }
    }
}
