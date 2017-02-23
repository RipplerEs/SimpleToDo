using System;

namespace SimpleToDo.Aggregates
{
    public class ToDoItemState
    {
        private readonly Guid _owner;
        private bool _isCompleted = false;
        private bool _descriptionTextSet = false;

        public ToDoItemState(Guid owner)
        {
            _owner = owner;
        }

        public bool IsAuthorized(Guid userRef)
        {
            return userRef == _owner;
        }

        public bool IsComplete()
        {
            return _isCompleted;
        }

        public bool IsDescriptionTextSet()
        {
            return _descriptionTextSet;
        }

        public void Complete()
        {
            _isCompleted = true;
        }

        public void SetDescriptionText(string descriptionText)
        {
            _descriptionTextSet = !string.IsNullOrWhiteSpace(descriptionText);
        }
    }

    public static class StateExtension
    {
        public static bool Exists(this ToDoItemState toDoItemState)
        {
            return toDoItemState != null;
        }
    }
}