using Domain.Entities.Security.Roles;
using Domain.Entities.Security.Users;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Aplication.Identity.Security.Users.Update
{
    public sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ErrorOr<Unit>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork)); 

            
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            if (Email.Create(command.Email) is not { } email)
            {
                return Error.Validation("Email.Invalid", "El correo electronico es invalido");
            }
            if (Password.Create(command.Password) is not { } password)
            {
                return Error.Validation("Password.Invalid", "La contraseña es invalida");
            }
            if (command.IdRoles.Count() == 0)
            {
                return Error.Validation("Role.Empty", "El usuario  debe tener al menos un rol");
            }

           

            User user = User.UpdateUser(new UserId(Guid.NewGuid()), command.Name, command.FistLastName, command.SecondLastName,email,new(), command.UserName,password);

            foreach (var item in command.IdRoles)
            {

                //user.AssignRole()//obtenre el rol por id ya signarlo a la lista
                
            }

            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;


        }
    }
}
