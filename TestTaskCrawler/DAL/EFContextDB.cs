using System.Data.Common;
using System.Data.Entity;
using TestTaskCrawler.Models;

namespace TestTaskCrawler.DAL
{

    public class EFContextDB : DbContext
    {
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        public EFContextDB() : base("Server=(localdb)\\MSSQLLocalDB;Database=EFContextDB;Trusted_Connection=True;MultipleActiveResultSets=true")
        {

        }
    }
}
