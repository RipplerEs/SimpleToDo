using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleToDo.Models.ToDoItem
{
    [Table("ToDoItems")]
    public class ToDoItemView
    {
        [Key]
        public Guid Id { get; set; }
        public int Version { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public Guid Owner { get; set; }
    }
}
