using System;
using System.Data.Entity;
using TestTaskCrawler.Models;

namespace TestTaskCrawler.DAL
{
    public class EFContextDB : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }

        public EFContextDB() : base("Name=EFContextDB")
        {
            Database.SetInitializer<EFContextDB>(new CreateDatabaseIfNotExists<EFContextDB>());

            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
        }

    }
}
