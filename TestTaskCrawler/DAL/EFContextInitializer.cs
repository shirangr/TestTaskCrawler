using System.Collections.Generic;
using System.Data.Entity;
using TestTaskCrawler.Models;

namespace TestTaskCrawler.DAL
{
    public class EFContextInitializer : DropCreateDatabaseAlways<EFContext>
    {
        protected override void Seed(EFContext context)
        {
            //IList<Account> users = new List<Account>();

            //users.Add(new Account() { Username = "", Password = "", FirstTimeLoggedIn = "", LastLoggedIn = "" });

            //context.Users.AddRange(users);

            //base.Seed(context);
        }
    }
}
