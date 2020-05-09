using CleanArchitecture.Application.ToDoItems.Queries;
using CleanArchitecture.Core;
using CleanArchitecture.Core.Aggregates;
using CleanArchitecture.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IRepository<int> _repository;
        private readonly IMediator _mediator;

        public ToDoController(IRepository<int> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _mediator.Send(new GetTodoItemListQuery());
            return View(items);
        }

        public IActionResult Populate()
        {
            int recordsAdded = DatabasePopulator.PopulateDatabase(_repository);
            return Ok(recordsAdded);
        }
    }
}
