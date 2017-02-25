using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleToDo.ViewMaterializer.Views
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
