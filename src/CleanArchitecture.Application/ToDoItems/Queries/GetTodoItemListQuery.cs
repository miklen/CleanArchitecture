using CleanArchitecture.Core.Aggregates.ToDoAggregate;
using CleanArchitecture.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.ToDoItems.Queries
{
    public class GetTodoItemListQuery : IRequest<IEnumerable<ToDoItemDTO>>
    {
    }

    public class GetTodoItemListQueryHandler : IRequestHandler<GetTodoItemListQuery, IEnumerable<ToDoItemDTO>>
    {
        private readonly IRepository<int> _repository;

        public GetTodoItemListQueryHandler(IRepository<int> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ToDoItemDTO>> Handle(GetTodoItemListQuery request, CancellationToken cancellationToken)
        {
            return (await _repository.ListAsync<ToDoItem>())
                           .Select(ToDoItemDTO.FromToDoItem);
        }
    }
}
