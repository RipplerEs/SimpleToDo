using System;
using RipplerES.CommandHandler;

namespace SimpleToDo.Aggregates
{
    public class CreateFor : IAggregateCommand<ToDoItem>
    {
        public CreateFor(Guid userRef)
        {
            UserRef = userRef;
        }

        public Guid UserRef { get; }
    }
}