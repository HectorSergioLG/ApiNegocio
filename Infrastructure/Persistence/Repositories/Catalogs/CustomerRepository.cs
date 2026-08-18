using Domain.Entities.Catalogs.Customer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Catalogs
{
    /// <summary>
    /// Implementación del repositorio de Customers.
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CustomerRepository"/>.
        /// </summary>
        /// <param name="Customer"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public void Add(Customer customer)=>  _context.Customers.AddAsync(customer);
       
        /// <summary>
        /// Elimina un Customer del repositorio.
        /// </summary>
        /// <param name="Customer"></param>
        public void Delete(Customer customer) => _context.Customers.Remove(customer);

        /// <summary>
        /// Actualiza un Customer existente en el repositorio.
        /// </summary>
        /// <param name="Customer"></param>
        public void Update(Customer customer) => _context.Customers.Update(customer);

        /// <summary>
        /// Obtiene un Customer por su identificador único.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> Exists(CustomerId id)=> _context.Customers.AnyAsync(c => c.Id == id);

        /// <summary>
        /// Obtiene un Customer por su identificador único.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Customer?> GetById(CustomerId id) => await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);

        /// <summary>
        /// Obtiene todos los Customers del repositorio.
        /// </summary>
        /// <returns></returns>
        public Task<List<Customer>> GetAll() => _context.Customers.ToListAsync();

       
    }
}
