using System.Collections.Generic;

namespace CleanArchitecture.SharedKernel
{
    // This can be modified to BaseEntity<TId> to support multiple key types (e.g. Guid)
    public abstract class BaseEntity<TId> : IDomainEventable
    {
        public TId Id { get; set; }

        public List<BaseDomainEvent> Events { get; } = new List<BaseDomainEvent>();
    }
}