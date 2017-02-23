using System;
using RipplerES.CommandHandler;

namespace SimpleToDo.Aggregates
{
    public class CompleteToDoItem : IAggregateCommand<ToDoItem>
    {
        public Guid UserRef { get; }
        public CompleteToDoItem(Guid userRef)
        {
            UserRef = userRef;
        }
    }
}