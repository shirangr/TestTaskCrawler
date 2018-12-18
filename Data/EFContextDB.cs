using Microsoft.EntityFrameworkCore;
using System.Linq;
using TestTaskCrawler.Models;

namespace TestTaskCrawler.DAL
{

    public class EFContextDB : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }


        public EFContextDB(DbContextOptions<EFContextDB> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<Account>(entity =>
            //{
            //    entity.Property(e => e.Username).IsRequired();
            //    entity.Property(e => e.Username).HasColumnType("EmailAddress");
                
            //    entity.Property(e => e.Password).IsRequired();
            //    entity.Property(e => e.Password).HasColumnType("Password");
            //});

            //modelBuilder.Entity<Product>(entity =>
            //{
            //    entity.Property(b => b.Price).HasColumnType("decimal(5, 2)");
            //    entity.Property(b => b.ShippingPrice).HasColumnType("decimal(5, 2)");

            //});


            //modelBuilder.Entity<Product>()
            //.HasOne(p => p.Account)
            //.WithMany(b => b.Products);
            ////.HasForeignKey(p => p.Username);
        }
    }
}

