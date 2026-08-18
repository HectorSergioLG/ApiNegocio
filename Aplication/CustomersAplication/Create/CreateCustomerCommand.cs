using ErrorOr;
using MediatR;

namespace Aplication.CustomersAplication.Create
{
    /// <summary>
    /// Comando para crear un nuevo cliente, estos son los parametros nesesarios.
    /// </summary>
    /// <param name="Nombre"></param>
    /// <param name="ApellidoPaterno"></param>
    /// <param name="ApellidoMaterno"></param>
    /// <param name="CorreoElectronico"></param>
    /// <param name="NumeroTelefonico"></param>
    public record CreateCustomerCommand(
        string Name,
        string FistLastName,
        string SecondLastName,
        string Email,
        string PhoneNumber
    ) : IRequest<ErrorOr<Unit>>;
}
