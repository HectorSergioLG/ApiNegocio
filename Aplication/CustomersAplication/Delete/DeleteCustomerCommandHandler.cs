using Domain.Entities.Catalogs.Customer;
using Domain.Primitives;
using ErrorOr;

namespace Aplication.CustomersAplication.Delete
{
    internal sealed class DeleteCustomerCommandHandler
    {
        private readonly ICustomerRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(ICustomerRepository clienteRepository, IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<MediatR.Unit>> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            if (await _clienteRepository.GetById( new CustomerId(command.Id)) is not Customer customr)
            {
                return Error.NotFound("Cliente.NoFound", "El cliente no fue encontrado.");
            }
             
            _clienteRepository.Delete(customr);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return MediatR.Unit.Value;
        }

    }
}
