using System;
using RipplerES.CommandHandler;

namespace SimpleToDo.Aggregates
{
    public class DescriptionSet : IAggregateEvent<ToDoItem>
    {
        public string DescriptionText { get; }
        public Guid UserRef { get; }

        public DescriptionSet(string descriptionText, Guid userRef)
        {
            DescriptionText = descriptionText;
            UserRef = userRef;
        }
    }
}