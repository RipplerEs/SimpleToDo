using Newtonsoft.Json.Linq;
using RipplerAccountTest.AccountSummaryView;
using RipplerES.SubscriptionHandler;
using SimpleToDo.ViewMaterializer.Views;

namespace SimpleToDo.ViewMaterializer
{
    public class HandleCompleted: ToDoItemViewEventHandler, IEventHandler
    {
        public HandleCompleted(ViewDataContext viewRepository) : base(viewRepository)
        {
        }

        protected override void Apply(ToDoItemView view, int version, string data)
        {
            dynamic json = JObject.Parse(data);
            view.Version = version;
            view.IsComplete = true;
        }
        public bool CanHandle(string aggregateType, string eventType)
        {
            return aggregateType ==
                   "SimpleToDo.Aggregates.ToDoItem, SimpleToDo.Aggregates, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
                        && eventType == "SimpleToDo.Aggregates.Completed, SimpleToDo.Aggregates, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
        }

        public bool CanHandle(string aggregateYype)
        {
            return false;
        }
    }
}