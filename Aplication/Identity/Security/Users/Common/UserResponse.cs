using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Security.Users.Common
{
    public record UserResponse(
        Guid id,
        string Name,
        string FistLastName,
        string SecondLastName,
        string Email,
        string UserName,
        string Password,
        DateTime RegistrationDate,
        List<string> IdRoles,
        bool Active);
}
