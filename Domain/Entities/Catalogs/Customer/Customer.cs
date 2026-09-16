using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities.Catalogs.Customer
{
    /// <summary>
    /// Representa un Customer en el sistema.
    /// </summary>
    public class Customer:AggregateRoot
    {
        public Customer(CustomerId id, string name, string fistLastName, string secondLastName, Email email, PhoneNumber phoneNumber, bool isActive)
        {
            Id = id;
            Name = name;
            FistLastName = fistLastName;
            SecondLastName = secondLastName;
            Email = email;
            PhoneNumber = phoneNumber;
            IsActive = isActive;
        }

       
        public static Customer UpdateCustomer(Guid id, string name, string fistLastName, string secondLastName, Email email, PhoneNumber phoneNumber, bool isActive)
        {
            return new Customer(new CustomerId(id), name, fistLastName, secondLastName, email, phoneNumber, isActive);
        }

        /// <summary>
        /// Obtiene el identificador del Customer.
        /// </summary>
        public CustomerId Id { get; private set; }
        /// <summary>
        /// Obtiene el nombre del Customer.
        /// </summary>
        public string Name {  get; private set; }
        /// <summary>
        /// Obtiene el apellido paterno del Customer.
        /// </summary>
        public string FistLastName { get; private set; } = string.Empty;
        /// <summary>
        /// Obtiene el apellido materno del Customer.
        /// </summary>
        public string SecondLastName { get; private set; } = string.Empty;
        /// <summary>
        /// Obtiene el correo electrónico del Customer.
        /// </summary>
        public Email Email { get; private set; }
        /// <summary>
        /// Obtiene el número telefónico del Customer.
        /// </summary>
        public PhoneNumber PhoneNumber { get; private set; }
        //public string Direccion { get; private set; } no se si se utilizara para mi sistema 
        /// <summary>
        /// Obtiene un valor que indica si el Customer está activo.
        /// </summary>
        public bool IsActive { get; private set; }

        public void Disable()
        {
            IsActive = false;
        }

        public void Enable()
        {
            IsActive = true;
        }
    }
}
