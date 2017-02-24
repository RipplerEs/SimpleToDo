using System;
using RipplerES.CommandHandler;
using SimpleToDo.Aggregates;

namespace SimpleToDo.Controllers
{
    public class RipplerAggregateException : Exception
    {
        public CommandErrorResult<ToDoItem> Error { get; }

        public RipplerAggregateException(CommandErrorResult<ToDoItem> error)
        {
            Error = error;
        }
    }
}