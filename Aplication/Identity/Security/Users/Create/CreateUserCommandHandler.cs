using Domain.Entities.Security.Users;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;


namespace Aplication.Identity.Security.Users.Create
{
    internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ErrorOr<Unit>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork)) ;
        }

        public async Task<ErrorOr<Unit>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (Email.Create(request.Email) is not { } email)
            {
                return Error.Validation("Email.Invalid", "El correo electronico es invalido");
            }
            if (!DateTime.TryParse(request.RegistrationDate, out DateTime registrationDate))
            {
                return Error.Validation("RegistrationDate.Invalid", "La fecha de registro es invalida");
            }
            if (Password.Create(request.Password) is not { } password)
            {
                return Error.Validation("Password.Invalid", "La contraseña es invalida");
            }
            if (request.IdRoles.Count()==0)
            {
                return Error.Validation("Role.Empty", "El usuario  debe tener al menos un rol");
            }

            var user = new User(
                new UserId(Guid.NewGuid()),
                request.Name,
                request.FistLastName,
                request.SecondLastName,
                email,
                new(),
                request.UserName,
                password,
                registrationDate,
                true
             );

            foreach (var item in request.IdRoles)
            {

               //user.AssignRole()//obtenre el rol por id

            }

            _userRepository.Add(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
