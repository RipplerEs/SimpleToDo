using System;
using RipplerES.CommandHandler;

namespace SimpleToDo.Aggregates
{
    public class Complete : IAggregateCommand<ToDoItem>
    {
        public Guid UserRef { get; }
        public Complete(Guid userRef)
        {
            UserRef = userRef;
        }
    }
}