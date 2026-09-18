using Domain.Entities.Catalogs.Customer;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Catalogos.Customers.Delete
{
    internal sealed class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, ErrorOr<Unit>>
    {
        private readonly ICustomerRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(ICustomerRepository clienteRepository, IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            if (await _clienteRepository.GetById( new CustomerId(command.Id)) is not Customer customr)
            {
                return Error.NotFound("Cliente.NoFound", "El cliente no fue encontrado.");
            }
             
            _clienteRepository.Delete(customr);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}
