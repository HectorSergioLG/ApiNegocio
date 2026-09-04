using Aplication.Identity.Catalogos.Customers.Common;
using Aplication.Identity.Security.Users.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Identity.Security.Users.GetAll
{
    public record GetAllUserQuery() : IRequest<ErrorOr<IReadOnlyList<UserResponse>>>; 
    
}
