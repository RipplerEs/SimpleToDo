using RipplerES.CommandHandler;

namespace SimpleToDo.Aggregates
{
    public class Register : IAggregateCommand<User>
    {
        public string UserName { get; }

        public Register(string userName)
        {
            UserName = userName;
        }
    }
}