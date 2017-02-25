using System;
using System.Threading;
using Microsoft.Extensions.Configuration;
using RipplerAccountTest.AccountSummaryView;
using RipplerES.Repositories.SqlServer;
using RipplerES.SubscriptionHandler;

namespace SimpleToDo.ViewMaterializer
{
    public class Program
    {
        private static readonly Guid _channel = 
            Guid.Parse("{7BECADD8-32EA-400E-AEA7-E8B75957CAED}");

        public static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder()
                .AddJsonFile("Config.json");


            var viewDataContext = new ViewDataContex();
            var subscriptionHandler = new SubscriptionHandler(
                    _channel,
                    "ToDoListView",
                    new SqlServerSubscriptionRepository(builder.Build()),
                    new ITypedEventHandler[]
                    {
                        new HandleCreatedFor(viewDataContext),
                        new HandleSetDescription(viewDataContext),
                        new HandleCompleted(viewDataContext),  
                    }, null);

            subscriptionHandler.Initialize();
            while (true)
            {
                subscriptionHandler.Execute();
                Thread.Sleep(100);
            }
        }
    }
}
