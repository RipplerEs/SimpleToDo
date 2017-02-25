using System;
using System.Linq;
using RipplerAccountTest.AccountSummaryView;
using RipplerES.SubscriptionHandler;
using SimpleToDo.ViewMaterializer.Views;

namespace SimpleToDo.ViewMaterializer
{
    public abstract class ToDoItemViewEventHandler : IEventHandler
    {
        private readonly ViewDataContex _viewRepository;
        protected ToDoItemViewEventHandler(ViewDataContex viewRepository)
        {
            _viewRepository = viewRepository;
        }

        public void Handle(Guid aggregateId, int version, string data, string metaData)
        {
            ToDoItemView toDoItemView;
            if (version == 1)
            {
                toDoItemView = new ToDoItemView
                {
                    Id = aggregateId,
                    Version = version - 1
                };
                _viewRepository.ToDoItems.Add(toDoItemView);
            }
            else
            {
                toDoItemView = _viewRepository.ToDoItems
                    .Single(c => c.Id == aggregateId);
            }

            if (toDoItemView.Version != version - 1)
                throw new Exception("Unexpected version");

            Apply(toDoItemView, version, data);
            _viewRepository.SaveChanges();
        }

        protected abstract void Apply(ToDoItemView view, int version, string data);
    }
}