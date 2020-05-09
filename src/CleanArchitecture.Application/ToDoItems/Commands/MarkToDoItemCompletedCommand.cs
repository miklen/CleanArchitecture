using CleanArchitecture.Core.Aggregates.ToDoAggregate;
using CleanArchitecture.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.ToDoItems.Commands
{
    public class MarkToDoItemCompletedCommand : IRequest<ToDoItemDTO>
    {
        public int Id { get; set; }
    }

    public class MarkToDoItemCompletedCommandHandler : IRequestHandler<MarkToDoItemCompletedCommand, ToDoItemDTO>
    {
        private readonly IRepository<int> _repository;

        public MarkToDoItemCompletedCommandHandler(IRepository<int> repository)
        {
            _repository = repository;
        }

        public async Task<ToDoItemDTO> Handle(MarkToDoItemCompletedCommand request, CancellationToken cancellationToken)
        {
            var toDoItem = await _repository.GetByIdAsync<ToDoItem>(request.Id);
            toDoItem.MarkComplete();
            await _repository.UpdateAsync(toDoItem);
            return ToDoItemDTO.FromToDoItem(toDoItem);
        }
    }
}
