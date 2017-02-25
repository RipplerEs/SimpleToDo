using RipplerES.CommandHandler;

#region Aliases
using Result = RipplerES.CommandHandler.IAggregateCommandResult<SimpleToDo.Aggregates.ToDoItem>;
#endregion

namespace SimpleToDo.Aggregates
{
    public class ToDoItem : AggregateBase<ToDoItem>
    {
        private ToDoItemState _toDoItemState;

        #region Create
        public Result Execute(CreateFor command)
        {
            if (!_toDoItemState.Exists()) return Error(new ToDoItemNotFound());
            return Success(new CreatedFor(userRef: command.UserRef));
        }

        public void Apply(CreatedFor @event)
        {
            _toDoItemState = new ToDoItemState(@event.UserRef);
        }
        #endregion

        #region Set Description
        public Result Execute(SetDescription command)
        {
            if (!_toDoItemState.Exists()) return Error(new ToDoItemNotFound());
            if (!_toDoItemState.IsAuthorized(command.UserRef)) return Error(new ToDoItemAccessDenied());
            if (_toDoItemState.IsComplete()) return Error(new CannotChangeToDoItemDescriptionWhenComplete());
            if (string.IsNullOrWhiteSpace(command.DescriptionText))
            {
                return Error(new ToDoItemDescriptionCannotBeEmpty());
            }

            return Success(new DescriptionSet(descriptionText: command.DescriptionText, 
                                              userRef: command.UserRef));
        }

        public void Apply(DescriptionSet @event)
        {
            _toDoItemState.SetDescriptionText(@event.DescriptionText);
        }
        
        #endregion

        #region Complete
        Result Execute(Complete command)
        {
            {
                if (!_toDoItemState.Exists()) return Error(new ToDoItemNotFound());
                if (!_toDoItemState.IsAuthorized(command.UserRef)) return Error(new ToDoItemAccessDenied());
                if (!_toDoItemState.IsDescriptionTextSet()) return Error(new ToDoItemDescriptionTextNotSet());

                return Success(new Completed(userRef: command.UserRef));
            }
        }
        #endregion
    }
}
