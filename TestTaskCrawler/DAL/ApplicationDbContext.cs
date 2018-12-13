using System.Data.Entity;
using TestTaskCrawler.Models;

namespace TestTaskCrawler.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("CrawlerDB")
        {
            //Database.SetInitializer<ApiContext>(new CreateDatabaseIfNotExists<ApiContext>());
            //Database.SetInitializer<ApiContext>(new DropCreateDatabaseIfModelChanges<ApiContext>());
        }

        public DbSet<Account> Users { get; set; }

        public DbSet<Product> Products { get; set; }
    }



}
