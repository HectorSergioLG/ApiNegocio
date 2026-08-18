using Aplication.CustomersAplication.Common;
using Domain.Entities.Catalogs.Customer;

namespace Aplication.CustomersAplication.GetAll
{
   
    class GetAllCustomerQueryHandler
    {
        private readonly ICustomerRepository _clienteRepository;
        public GetAllCustomerQueryHandler(ICustomerRepository clienteRepository)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        public async Task<IReadOnlyList<CustomerResponse>> Handle(GetAllCustomerQuery query, CancellationToken cancellationToken)
        {
           IReadOnlyList<Customer> customers = await _clienteRepository.GetAll();
            
           return customers.Select(customer => new CustomerResponse(
                customer.Id.Value,
                customer.Name,
                customer.FistLastName,
                customer.SecondLastName,
                customer.Email.Value,
                customer.PhoneNumber.Value,
                customer.Active
            )).ToList();

        }
    }
}
