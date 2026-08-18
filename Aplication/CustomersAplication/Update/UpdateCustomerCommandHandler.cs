using Domain.Entities.Catalogs.Customer;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Aplication.CustomersAplication.Update
{
     internal sealed class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, ErrorOr<Unit>>
    {
        private readonly ICustomerRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerCommandHandler(ICustomerRepository repository, IUnitOfWork unitOfWork)
        {
            _clienteRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            if (!await _clienteRepository.Exists(new CustomerId(command.Id)))
            {
                return Error.NotFound("Cliente.NoFound", "El cliente no fue encontrado.");
            }


            if (PhoneNumber.Create(command.PhoneNumber) is not PhoneNumber phoneNumber)
            {
                return Error.Validation("Cliente.NumeroTelefonico", "El número de teléfono no es válido."); 
            }
            if (Email.Create(command.Email) is not { } email)
            {
                return Error.Validation("Email.Invalid", "El correo electronico es invalido");
            }

            Customer cliente = Customer.UpdateCustomer(
                command.Id, 
                command.Name, 
                command.FistLastName, 
                command.SecondLastName,
                email,
                phoneNumber, 
                command.Active);
            _clienteRepository.Update(cliente);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
