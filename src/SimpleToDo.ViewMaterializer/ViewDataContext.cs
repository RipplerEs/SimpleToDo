using Microsoft.EntityFrameworkCore;
using SimpleToDo.ViewMaterializer.Views;

namespace RipplerAccountTest.AccountSummaryView
{
    public class ViewDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=RipplesES-EventStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True");
        }

        public DbSet<ToDoItemView> ToDoItems { get; set; }
    }
}