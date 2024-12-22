﻿namespace Ordering.Domain.Abstractions
{
    public interface IAggregate<T> : IAggregate, IEntity
    {
    }

    public interface IAggregate : IEntity
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

        IDomainEvent[] ClearDomainEvents();
    }
}
