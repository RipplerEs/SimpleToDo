using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using RipplerES.CommandHandler;
using SimpleToDo.Aggregates;
using SimpleToDo.Data;
using SimpleToDo.Models.ToDoItem;
using Complete = SimpleToDo.Models.ToDoItem.Complete;

namespace SimpleToDo.Controllers
{
    [Produces("application/json")]
    [Route("api/ToDoItem")]
    public class ToDoItemController : Controller
    {
        private readonly Dispatcher _dispatcher;
        private readonly ApplicationDbContext _dbContext;

        public ToDoItemController(Dispatcher dispatcher,
            ApplicationDbContext dbContext)
        {
            _dispatcher = dispatcher;
            _dbContext = dbContext;
        }


        [HttpPost]
        public ActionResult SetDescription([FromBody] NewToDoItem toDoItem)
        {
            var id = Guid.NewGuid();
            var version = -1;

            var currentUserId = Guid.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = _dispatcher.Execute(id, version,
                new SetDescription(userRef: currentUserId,
                    descriptionText: toDoItem.Description));

            var error = result as CommandErrorResult<ToDoItem>;
            if (error != null)
            {
                throw new RipplerAggregateException(error);
            }
            return Ok();
        }

        [Route("Update")]
        [HttpPut]
        public ActionResult SetDescription([FromBody] DescriptionUpdate descriptionUpdate)
        {
            var currentUserId = Guid.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = _dispatcher.Execute(descriptionUpdate.Id, descriptionUpdate.Version,
                new SetDescription(userRef: currentUserId,
                    descriptionText: descriptionUpdate.Description));

            var error = result as CommandErrorResult<ToDoItem>;
            if (error != null)
            {
                throw new RipplerAggregateException(error);
            }

            return Ok();
        }

        [Route("Complete")]
        [HttpPut()]
        public ActionResult Complete([FromBody] Complete complete)
        {
            var currentUserId = Guid.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = _dispatcher.Execute(complete.Id,
                complete.Version,
                new Aggregates.Complete(userRef: currentUserId));

            var error = result as CommandErrorResult<ToDoItem>;
            if (error != null)
            {
                throw new RipplerAggregateException(error);
            }

            return Ok();
        }

        [HttpGet]
        public ActionResult GetToDoItems()
        {
            var currentUserId = Guid.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var data = _dbContext.ToDoItems.Where(c => c.Owner == currentUserId);
            Response.Headers.Add("Version", data.Sum(c=>c.Version).ToString());

            return Json(data);
        }

        [Route("Version")]
        [HttpHead]
        public ActionResult GetVersion()
        {
            var currentUserId = Guid.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var data = _dbContext.ToDoItems.Where(c => c.Owner == currentUserId);
            Response.Headers.Add("Version", data.Sum(c => c.Version).ToString());

            return Json(data);
        }
    }
}