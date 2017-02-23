using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RippleES.Serialization.Json;
using RipplerES.CommandHandler;
using RipplerES.Repositories.SqlServer;
using SimpleToDo.Aggregates;

namespace SimpleToDo
{
    public class BootStrapper : BootstrapperBase
    {
        public BootStrapper(IServiceCollection serviceCollection,
            IConfiguration configuration) : base(serviceCollection, configuration)
        {
            
        }

        protected override void RegisterHander()
        {
            RegisterHandlerFor<User>();
            RegisterHandlerFor<ToDoItem>();
        }

        protected override void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IEventRepository, SqlServerEventRepository>();
            serviceCollection.AddTransient<ISerializer, JsonSerializer>();
        }
    }
}
