﻿using RipplerES.CommandHandler;

#region Aliases
using Result= RipplerES.CommandHandler.IAggregateCommandResult<SimpleToDo.Aggregates.User>;
#endregion


namespace SimpleToDo.Aggregates
{
    public class User : AggregateBase<User>
    {
        Result Execute(Register command)
        {
            return Success(new Registered(userName: command.UserName));
        }
    }
}
