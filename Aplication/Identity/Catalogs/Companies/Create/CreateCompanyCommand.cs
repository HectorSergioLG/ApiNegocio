using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogs.Companies.Create
{
    public sealed record CreateCompanyCommand(
        string Name,
        string TradeName,
        string Email,
        string PhoneNumber
     ):IRequest<ErrorOr<Unit>>;
}
