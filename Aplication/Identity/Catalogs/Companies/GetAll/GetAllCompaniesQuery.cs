using Aplication.Identity.Catalogos.Companies.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Catalogos.Companies.GetAll
{
    public record GetAllCompaniesQuery() : IRequest<ErrorOr<IReadOnlyList<CompanyResponse>>>;

}
