namespace Aplication.Identity.Catalogos.Customers.Common
{
    public record CustomerResponse(
        Guid Id,
        string Name,
        string FistLastName,
        string SecondLastName,
        string Email,
        string phoneNumber,
        bool IsActive
        );
}
