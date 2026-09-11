using Aplication.Identity.Security.Users.Common;
using Domain.Entities.Security.Users;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Security.Users.GetById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ErrorOr<UserResponse>>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }
        public async Task<ErrorOr<UserResponse>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetById(new UserId(query.Id)) is not User user)
            {
                return Error.NotFound("User.NoFound", "El cliente no fue encontrado.");
            } 

            return new UserResponse(
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
             );
        }
    }
}
