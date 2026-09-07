using Domain.Entities.Catalogs.Customer;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Customers.Create
{
    /// <summary>
    /// Clase para manejar el comando CreateClienteCommand, este se encarga de crear un nuevo cliente en la base de datos.
    /// </summary>
    internal sealed class CreateCustomerCommandHandler:IRequestHandler<CreateCustomerCommand, ErrorOr<Unit>>
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor de la clase CreateClienteCommanHandler
        /// </summary>
        /// <param name="clienteRepository"></param>
        /// <param name="unitOfWork"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public CreateCustomerCommandHandler(ICustomerRepository clienteRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        /// <summary>
        /// Manejador del comando CreateClienteCommand, este se encarga de crear un nuevo cliente en la base de datos.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ErrorOr<Unit>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (PhoneNumber.Create(request.PhoneNumber) is not { } phoneNumber)
            {
                return Error.Validation("NumeroTelefonico.Invalid","El número telefónico es inválido.");
            }
            if (Email.Create(request.Email)is not { } email)
            {
                return Error.Validation("Email.Invalid", "El correo electronico es invalido");
            }
            var cliente = new Customer(
                new CustomerId(Guid.NewGuid()),
                request.Name,
                request.FistLastName, 
                request.SecondLastName,
                email,
                phoneNumber,
                true
            );
            _customerRepository.Add(cliente);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
