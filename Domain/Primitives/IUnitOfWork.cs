using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Primitives
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Agrega un nuevo cliente al repositorio.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
