namespace Domain.Entities.Catalogs.Customer
{
    /// <summary>
    /// Representa el identificador único de un Customer.
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Obtiene todos los Customers del repositorio.
        /// </summary>
        /// <returns></returns>
        Task<List<Customer>> GetAll();

        /// <summary>
        /// Obtiene un Customer por su identificador único.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Customer?> GetById(CustomerId id);

        /// <summary>
        /// Verifica si un Customer existe en el repositorio por su identificador único.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Exists(CustomerId id);
        
        /// <summary>
        /// Agrega un nuevo Customer al repositorio.
        /// </summary>
        /// <param name="Customer"></param>
        /// <returns></returns>
        void Add(Customer Customer);

        /// <summary>
        /// Elimina un Customer del repositorio.
        /// </summary>
        /// <param name="Customer"></param>
        /// <returns></returns>
        void Delete(Customer Customer);

        /// <summary>
        /// Actualiza un Customer existente en el repositorio.
        /// </summary>
        /// <param name="Customer"></param>
        /// <returns></returns>
        void Update(Customer Customer);
    }
}
