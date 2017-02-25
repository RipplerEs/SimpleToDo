using Microsoft.EntityFrameworkCore;
using SimpleToDo.ViewMaterializer.Views;

namespace RipplerAccountTest.AccountSummaryView
{
    public class ViewDataContex : DbContext
    {
        public DbSet<ToDoItemView> ToDoItems { get; set; }
    }
}