using Newtonsoft.Json.Linq;
using RipplerAccountTest.AccountSummaryView;
using RipplerES.SubscriptionHandler;
using SimpleToDo.ViewMaterializer.Views;

namespace SimpleToDo.ViewMaterializer
{
    public class HandleSetDescription: ToDoItemViewEventHandler, ITypedEventHandler
    {
        public HandleSetDescription(ViewDataContex viewRepository) : base(viewRepository)
        {
        }

        protected override void Apply(ToDoItemView view, int version, string data)
        {
            dynamic json = JObject.Parse(data);
            view.Version = version;
            view.Owner = json.Owner;
            view.Description = json.DescriptionText;
        }
        public bool CanHandle(string eventType)
        {
            return eventType == "SimpleToDo.Aggregates.SetDescription, SimpleToDo.Aggregates, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
        }
    }
}