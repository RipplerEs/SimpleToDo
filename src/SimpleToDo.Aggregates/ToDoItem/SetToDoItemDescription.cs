using System;
using RipplerES.CommandHandler;

namespace SimpleToDo.Aggregates
{
    public class SetDescription : IAggregateCommand<ToDoItem>
    {
        public Guid UserRef { get; }
        public string DescriptionText { get; }

        public SetDescription(Guid userRef, string descriptionText)
        {
            UserRef = userRef;
            DescriptionText = descriptionText;
        }
    }
}