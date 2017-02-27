using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RipplerES.CommandHandler;
using SimpleToDo.Aggregates;
using SimpleToDo.Data;
using SimpleToDo.Models;
using SimpleToDo.Models.ToDoItem;

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
        public ActionResult SetDescription(NewToDoItem toDoItem)
        {
            var id = Guid.NewGuid();
            var version = -1;

            //var currentUserId = Guid.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            //var result = _dispatcher.Execute(id, version,
            //    new SetDescription(userRef: currentUserId,
            //        descriptionText: toDoItem.Description));

            //var error = result as CommandErrorResult<ToDoItem>;
            //if (error != null)
            //{
            //    throw new RipplerAggregateException(error);
            //}

            //var newVersion = 0;
            //ToDoItemView fetched = null;

            //while (version < newVersion)
            //{
            //    fetched = _dbContext.ToDoItems.SingleOrDefault(c => c.Id == id);
            //    if (fetched != null)
            //        newVersion = fetched.Version;
            //}


            return Ok();//Json(fetched);
        }

        [HttpPut]
        public ActionResult Complete(Guid id, int version)
        {
            var currentUserId = Guid.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = _dispatcher.Execute(id,
                version,
                new Complete(userRef: currentUserId));

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

            return Json(data);
        }
    }
}