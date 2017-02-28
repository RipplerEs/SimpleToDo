using Microsoft.EntityFrameworkCore;
using SimpleToDo.ViewMaterializer.Views;

namespace RipplerAccountTest.AccountSummaryView
{
    public class ViewDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=aspnet-SimpleToDo-98804e1b-d298-442c-a709-28b7d8567e68;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<ToDoItemView> ToDoItems { get; set; }
    }
}