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
    public class CreateToDoItemCommand : IRequest<ToDoItemDTO>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }
    }

    public class CreateToDoItemCommandHandler : IRequestHandler<CreateToDoItemCommand, ToDoItemDTO>
    {
        private readonly IRepository<int> _repository;

        public CreateToDoItemCommandHandler(IRepository<int> repository)
        {
            _repository = repository;
        }

        public async Task<ToDoItemDTO> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = new ToDoItem() { Title = request.Title, Description = request.Description };
            await _repository.AddAsync(todoItem);
            return ToDoItemDTO.FromToDoItem(todoItem);
        }
    }
}
