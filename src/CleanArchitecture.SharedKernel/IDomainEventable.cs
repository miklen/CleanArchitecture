using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.SharedKernel
{
    public interface IDomainEventable
    {
        List<BaseDomainEvent> Events { get; }
    }
}
