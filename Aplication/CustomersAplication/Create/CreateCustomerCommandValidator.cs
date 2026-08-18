using FluentValidation;

namespace Aplication.CustomersAplication.Create
{
    /// <summary>
    /// Clase para validar los parametros del comando CreateClienteCommand
    /// </summary>
    public class CreateCustomerCommandValidator:AbstractValidator<CreateCustomerCommand>
    {
        /// <summary>
        /// Constructor de la clase CreateClienteCommandValidator, este se encarga de validar los parametros del comando CreateClienteCommand
        /// </summary>
        public CreateCustomerCommandValidator() { 
            RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
            RuleFor(x => x.FistLastName).NotEmpty().MaximumLength(150).WithName("Apellido Paterno");
            RuleFor(x => x.SecondLastName).NotEmpty().MaximumLength(150).WithName("Apellido Materno");
            RuleFor(x => x.Email).NotEmpty().MaximumLength(150).WithName("Correo Electrónico");
            RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(10).WithName("Número Telefónico");

        }
    }
}
