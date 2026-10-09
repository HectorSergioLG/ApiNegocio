using Domain.Entities.Catalogs.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogos.Companies.Common
{
    public record CompanyResponse(
        Guid Id,
        string Name,
        string TradeName,
        string Email,
        string PhoneNumber,
        bool IsActive
       );
    
}
