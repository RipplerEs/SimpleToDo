using System;
using RipplerES.CommandHandler;

namespace SimpleToDo.Aggregates
{
    public class ToDoItemCompleted : IAggregateEvent<ToDoItem>
    {
        public Guid UserRef { get; }

        public ToDoItemCompleted(Guid userRef)
        {
            UserRef = userRef;
            throw new NotImplementedException();
        }
    }
}