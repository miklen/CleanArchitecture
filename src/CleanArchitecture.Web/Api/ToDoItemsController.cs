using CleanArchitecture.Application.ToDoItems;
using CleanArchitecture.Application.ToDoItems.Commands;
using CleanArchitecture.Application.ToDoItems.Queries;
using CleanArchitecture.Core.Aggregates;
using CleanArchitecture.SharedKernel.Interfaces;
using CleanArchitecture.Web.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Api
{
    public class ToDoItemsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ToDoItemsController( IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await _mediator.Send(new GetTodoItemListQuery()));
        }

        // GET: api/ToDoItems
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetToDoItemQuery() { Id = id }));
        }

        // POST: api/ToDoItems
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDoItemDTO item)
        {
            var createCommand = new CreateToDoItemCommand()
            {
                Title = item.Title,
                Description = item.Description
            };
            return Ok(await _mediator.Send(createCommand));
        }

        [HttpPatch("{id:int}/complete")]
        public async Task<IActionResult> Complete(int id)
        {
            return Ok(await _mediator.Send(new MarkToDoItemCompletedCommand() { Id = id }));
        }
    }
}
