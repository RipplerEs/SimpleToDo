using System;
using RipplerES.CommandHandler;

#region Aliases
using Result = RipplerES.CommandHandler.IAggregateCommandResult<SimpleToDo.Aggregates.ToDoItem>;
#endregion

// ReSharper disable once CheckNamespace
namespace SimpleToDo.Aggregates
{
    public class ToDoItem : AggregateBase<ToDoItem>
    {
        #region State
        private class State
        {
            private Guid _owner;

            public State(Guid owner)
            {
                _owner = owner;
            }
        }
        #endregion

        private State _state;

        public Result Execute(CreateFor command)
        {
            return Success(new CreatedFor(userRef: command.UserRef));
        }

        public void Apply(CreatedFor @event)
        {
            _state = new State(@event.USerRef);
        }
    }
}
