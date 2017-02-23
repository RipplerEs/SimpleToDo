using RipplerES.CommandHandler;

namespace SimpleToDo.Aggregates
{
    public class Registered : IAggregateEvent<User>
    {
        public string UserName { get; }

        public Registered(string userName)
        {
            UserName = userName;
        }
    }
}