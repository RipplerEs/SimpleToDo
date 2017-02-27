using RipplerAccountTest.AccountSummaryView;
using RipplerES.SubscriptionHandler;
using SimpleToDo.ViewMaterializer.Views;

namespace SimpleToDo.ViewMaterializer
{
    public class UnhandledEventHandler : ToDoItemViewEventHandler, IEventHandler
    {
        public UnhandledEventHandler(ViewDataContext viewRepository) : base(viewRepository)
        {
        }

        protected override void Apply(ToDoItemView view, int version, string data)
        {
            view.Version = version;
        }

        public bool CanHandle(string aggregateType, string eventType)
        {
            return false;
        }

        public bool CanHandle(string aggregateType)
        {
            return aggregateType == "SimpleToDo.Aggregates.ToDoItem, SimpleToDo.Aggregates, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
        }
        
    }
}