using Aplication.Identity.Security.Users.Common;
using Domain.Entities.Security.Users;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Security.Users.GetAll
{
    public sealed class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, ErrorOr<IReadOnlyList<UserResponse>>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<IReadOnlyList<UserResponse>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<User> Users = await _userRepository.GetAll();

            return Users.Select(user => new UserResponse(
               user.Id.Value,
               user.Name,
               user.FistLastName,
               user.SecondLastName,
               user.Email.Value,
               user.UserName,
               user.Password.Value,
               user.RegistrationDate,
               user.Roles.Select(s => s.Id.Value.ToString()).ToList(),
               user.IsActive
             )).ToList();
        }

       
    }

}
