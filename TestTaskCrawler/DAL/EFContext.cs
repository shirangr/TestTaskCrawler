using System;
using System.Data.Entity;
using TestTaskCrawler.Models;

namespace TestTaskCrawler.DAL
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Name=EFContextDB")
        {
            //Database.SetInitializer<EFContext>(new EFContextInitializer());
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }

        
        //    //Database.SetInitializer<ApiContext>(new CreateDatabaseIfNotExists<ApiContext>());
        //    //Database.SetInitializer<ApiContext>(new DropCreateDatabaseIfModelChanges<ApiContext>());

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
            //Adds configurations for Student from separate class
            //modelBuilder.Configurations.Add(new StudentConfigurations());

            //modelBuilder.Entity<Account>()
            //    .ToTable("Account");

            //modelBuilder.Entity<Product>()
            //    .ToTable("Product");

            //modelBuilder.Entity<Account>()
            //    .MapToStoredProcedures();

            //modelBuilder.Entity<Product>()
            //    .MapToStoredProcedures();
        //}
    }



}
