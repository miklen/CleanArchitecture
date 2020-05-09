using CleanArchitecture.Core.Aggregates.ToDoAggregate;
using CleanArchitecture.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.ToDoItems.Queries
{
    public class GetToDoItemQuery : IRequest<ToDoItemDTO>
    {
        public int Id { get; set; }
    }

    public class GetToDoItemQueryHandler : IRequestHandler<GetToDoItemQuery, ToDoItemDTO>
    {
        private readonly IRepository<int> _repository;

        public GetToDoItemQueryHandler(IRepository<int> repository) 
        {
            _repository = repository;
        }

        public async Task<ToDoItemDTO> Handle(GetToDoItemQuery request, CancellationToken cancellationToken)
        {
            return ToDoItemDTO.FromToDoItem(await _repository.GetByIdAsync<ToDoItem>(request.Id));
        }
    }
}
