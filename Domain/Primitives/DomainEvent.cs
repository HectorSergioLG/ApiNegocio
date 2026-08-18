using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using MediatR;

namespace Domain.Primitives
{
    /// <summary>
    ///  Represents a domain event that can be raised by an aggregate root.
    /// </summary>
    /// <param name="id"></param>
    public record DomainEvent(Guid id) : INotification;
}
