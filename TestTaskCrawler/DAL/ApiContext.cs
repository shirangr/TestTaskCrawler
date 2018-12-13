using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskCrawler.Models;

namespace TestTaskCrawler.DAL
{
    public class ApiContext : DbContext
    {
        public ApiContext()
            : base("CrawlerDB")
        {
            //Database.SetInitializer<ApiContext>(new CreateDatabaseIfNotExists<ApiContext>());
            //Database.SetInitializer<ApiContext>(new DropCreateDatabaseIfModelChanges<ApiContext>());
        }

        public DbSet<Account> Users { get; set; }

        public DbSet<Product> Products { get; set; }
    }



}
