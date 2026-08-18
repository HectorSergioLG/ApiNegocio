namespace Aplication.CustomersAplication.Common
{
    public record CustomerResponse(
        Guid Id,
        string Nombre,
        string ApellidoPaterno,
        string ApellidoMaterno,
        string CorreoElectronico,
        string NumeroTelefonico,
        bool Activo
        );
}
