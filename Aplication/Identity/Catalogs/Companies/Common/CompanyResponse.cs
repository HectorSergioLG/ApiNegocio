using Domain.Entities.Catalogs.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogos.Companies.Common
{
    public record CompanyResponse(
        CompanyId Id,
        string Name, 
        bool IsActive
       );
    
}
