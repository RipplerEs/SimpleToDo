using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RipplerES.CommandHandler;
using SimpleToDo.Aggregates;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using SimpleToDo.Models;

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
        public HttpResponse Create()
        {
            var currentUserId = Guid.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = _dispatcher.Execute(Guid.NewGuid(), -1, new CreateFor(userRef: currentUserId));
            var error = result as CommandErrorResult<ToDoItem>;
            return Ok();
        }
    }
}