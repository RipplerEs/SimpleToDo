using System;
using RipplerES.CommandHandler;

namespace SimpleToDo.Aggregates
{
    public class Completed : IAggregateEvent<ToDoItem>
    {
        public Guid UserRef { get; }

        public Completed(Guid userRef)
        {
            UserRef = userRef;
            throw new NotImplementedException();
        }
    }
}