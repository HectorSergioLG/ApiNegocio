namespace Domain.Primitives
{
    /// <summary>
    /// Representa el identificador único de un cliente.
    /// </summary>
    public class AggregateRoot
    {
        /// <summary>
        /// Obtiene los eventos de dominio asociados al agregado.
        /// </summary>
        private readonly List<DomainEvent> _domainEvents = new();

        /// <summary>
        /// Agrega un evento de dominio al agregado.
        /// </summary>
        public ICollection<DomainEvent> DomainEvents => _domainEvents;

        /// <summary>
        /// Agrega un evento de dominio al agregado.
        /// </summary>
        /// <param name="domainEvent"></param>
        public void Raise(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
        /// <summary>
        /// Agrega un nuevo cliente al repositorio.
        /// </summary>
        /// <returns></returns>
        public ICollection<DomainEvent> GetDomainEvents()
        {

            return _domainEvents;
        }

    }
}
