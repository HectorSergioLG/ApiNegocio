using Aplication.CustomersAplication.Common;
using Domain.Entities.Catalogs.Customer;
using ErrorOr;

namespace Aplication.CustomersAplication.GetById
{
    internal sealed class GetCustomerByIdQueryHandler
    {
        private readonly ICustomerRepository _clienteRepository;
        public GetCustomerByIdQueryHandler(ICustomerRepository clienteRepository)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }
        public async Task<ErrorOr<CustomerResponse>> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {
            if (await _clienteRepository.GetById(new CustomerId(query.Id)) is not Customer customer)
            {
                return Error.NotFound("Cliente.NoFound", "El cliente no fue encontrado.");
            }
          

            return new CustomerResponse(
                customer.Id.Value,
                customer.Name,
                customer.FistLastName,
                customer.SecondLastName,
                customer.Email.Value,
                customer.PhoneNumber.Value,
                customer.Active
            );
        }
    }
}
