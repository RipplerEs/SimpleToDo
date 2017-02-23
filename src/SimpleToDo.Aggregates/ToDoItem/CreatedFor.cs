using System;
using RipplerES.CommandHandler;

namespace SimpleToDo.Aggregates
{
    public class CreatedFor : IAggregateEvent<ToDoItem>
    {
        public Guid UserRef { get; }

        public CreatedFor(Guid userRef)
        {
            UserRef = userRef;
        }
    }
}