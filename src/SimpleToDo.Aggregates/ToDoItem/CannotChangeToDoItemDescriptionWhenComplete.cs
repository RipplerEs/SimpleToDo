using RipplerES.CommandHandler;

namespace SimpleToDo.Aggregates
{
    public class CannotChangeToDoItemDescriptionWhenComplete : IAggregateError<ToDoItem>
    {
    }
}