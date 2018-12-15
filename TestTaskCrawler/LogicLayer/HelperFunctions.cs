using TestTaskCrawler.DAL;
using TestTaskCrawler.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TestTaskCrawler.LogicLayer
{
    public class HelperFunctions
    {
        /// <summary>
        /// Adds New user to db after signing up
        /// </summary>
        /// <param name="usrname"></param>
        /// <param name="pass"></param>
        public static Account AddUser(Account user)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<EFContextDB>();
                optionsBuilder.UseSqlServer("Data Source=TestTaskCrawlerDB");

                using (var db = new EFContextDB(optionsBuilder.Options))
                {
                    // Create and save a new user
                    var NewUser = new Account { Username = user.Username, Password = user.Password };
                    db.Accounts.Add(NewUser);
                    db.SaveChanges();

                    return NewUser;
                }


            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Gets all products
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static IQueryable<Product> GetAllProducts(Account user)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<EFContextDB>();
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestTaskCrawler.EFContextDB;Trusted_Connection=True;MultipleActiveResultSets=true");

                //add new
                using (var context = new EFContextDB(optionsBuilder.Options))
                {
                    //var query = from x in context.Products
                    //            where x.username == user.username
                    //            orderby by x.name
                    //            select x;

                    var query = context.Products.FromSql("SELECT * FROM Products WHERE username=@p0 order by Name Asc", new object[] { user.Username });

                    if (query != null)
                    {
                        return query;
                    }


                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }

        }


        //db
        //using (var context = new BloggingContext())
        //{
        //    // add
        //    context.Blogs.Add(new Blog { Url = "http://sample.com/blog_one" });
        //    context.Blogs.Add(new Blog { Url = "http://sample.com/blog_two" });

        //    // update
        //    var firstBlog = context.Blogs.First();
        //    firstBlog.Url = "";

        //    // remove
        //    var lastBlog = context.Blogs.Last();
        //    context.Blogs.Remove(lastBlog);

        //    context.SaveChanges();
        //}
    }

}
