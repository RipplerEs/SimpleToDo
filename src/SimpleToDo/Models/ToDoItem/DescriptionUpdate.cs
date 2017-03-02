using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleToDo.Models.ToDoItem
{
    public class DescriptionUpdate
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public string Description { get; set; }
    }

    public class NewToDoItem
    {
        public string Description { get; set; }
    }
}
