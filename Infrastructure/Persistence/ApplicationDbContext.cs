using Aplication.Data;
using Domain.Entities.Catalogs.Customer;
using Domain.Entities.Catalogs.Products.Brands;
using Domain.Entities.Catalogs.Products.Products;
using Domain.Entities.Catalogs.Products.UnitsMesures;
using Domain.Entities.Security.Permissions;
using Domain.Entities.Security.Roles;
using Domain.Entities.Security.Users;
using Domain.Primitives;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    /// <summary>
    /// Represents the application's database context, responsible for managing the database connection and providing access to the entities.
    /// </summary>
    public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
    {
        private readonly IPublisher _publisher;
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ApplicationDbContext"/> con las opciones y el publicador especificados.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="publisher"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options)
        {
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<UnitMeasure> UnitMeasures { get; set; }


        /// <summary>
        /// Guarda los cambios realizados en el contexto de la base de datos y publica los eventos de dominio asociados a las entidades.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var domainEvents = ChangeTracker.Entries<AggregateRoot>()
                .Select(e => e.Entity)
                .Where(w => w.GetDomainEvents().Any())
                .SelectMany(e => e.GetDomainEvents());
            
            var result = await base.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }

            return result;
        }

        /// <summary>
        /// Configura el modelo de la base de datos utilizando las configuraciones de las entidades.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            
        }
    }
}
