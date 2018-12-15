using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestTaskCrawler.Models;

namespace TestTaskCrawler.DAL
{

    public class EFContextDB : DbContext //: IdentityDbContext
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
            //    entity.Property(e => e.Password).IsRequired();
            //});

            //modelBuilder.Entity<Product>()
            //    .HasMany<Account>(g => g.Accounts).WithOne(s => s.Account_Product)
            //    .HasForeignKey(s => s.Account_ProductId);

            //base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestTaskCrawlerDB;Trusted_Connection=True;");
            }
        }
    }
}
