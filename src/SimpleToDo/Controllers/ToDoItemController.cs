using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RipplerES.CommandHandler;
using SimpleToDo.Aggregates;

namespace SimpleToDo.Controllers
{
    [Produces("application/json")]
    [Route("api/ToDoItem")]
    public class ToDoItemController : Controller
    {
        private readonly Dispatcher _dispatcher;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ToDoItemController(Dispatcher dispatcher,
                                  IHttpContextAccessor httpContextAccessor)
        {
            _dispatcher = dispatcher;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public ActionResult Create()
        {
            var toDoItemId = Guid.NewGuid();
            var currentUserId = Guid.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = _dispatcher.Execute(toDoItemId, -1, new CreateFor(userRef: currentUserId));

            var error = result as CommandErrorResult<ToDoItem>;
            if (error != null)
            {
                throw new RipplerAggregateException(error);
            }
            return Ok(toDoItemId);
        }

        [HttpPut]
        public ActionResult SetDescription(Guid id, int version, string descriptionText)
        {
            var currentUserId = Guid.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = _dispatcher.Execute(id, 
                                             version, 
                                             new SetDescription(userRef: currentUserId, 
                                                                descriptionText: descriptionText));

            var error = result as CommandErrorResult<ToDoItem>;
            if (error != null)
            {
                throw new RipplerAggregateException(error);
            }
            return Ok();
        }

        [HttpPut]
        public ActionResult Complete(Guid id, int version)
        {
            var currentUserId = Guid.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = _dispatcher.Execute(id,
                                             version,
                                             new CompleteToDoItem(userRef: currentUserId));

            var error = result as CommandErrorResult<ToDoItem>;
            if (error != null)
            {
                throw new RipplerAggregateException(error);
            }
            return Ok();
        }
    }
}