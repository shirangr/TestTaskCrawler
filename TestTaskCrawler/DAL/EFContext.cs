using System;
using System.Data.Entity;
using TestTaskCrawler.Models;

namespace TestTaskCrawler.DAL
{
    public class EFContext : DbContext
    {
        public DbSet<Account> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public static void addUser(string usrname, string pass)
        {
            Account usr = new Account() { Username = usrname, Password = pass };
            try
            {
                using (var ctx = new EFContext())
                {
                    ctx.Users.Add(usr);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }



}
