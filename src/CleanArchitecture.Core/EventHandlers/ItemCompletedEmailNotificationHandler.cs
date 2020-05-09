using Ardalis.GuardClauses;
using CleanArchitecture.Core.Aggregates.ToDoAggregate;
using CleanArchitecture.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.EventHandlers
{
    public class ItemCompletedEmailNotificationHandler : IHandle<ToDoItemCompletedEvent>
    {
        public Task Handle(ToDoItemCompletedEvent domainEvent)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));

            // Do Nothing
            return Task.CompletedTask;
        }
    }
}
