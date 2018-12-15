using TestTaskCrawler.DAL;
using TestTaskCrawler.Models;
using System;
using Microsoft.EntityFrameworkCore;

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
                    //var firsttimeloggedin = DateTime.Now;
                    //var NewUser = new Account { Username = user.Username, Password = user.Password, FirstTimeLoggedIn = firsttimeloggedin };
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
        /// returns product details from db/from web
        /// </summary>
        /// <param name="productUrl"></param>
        public static void GetProductDetailsByUrl(string productUrl)
        {
            //var crawler = new WebCrawler(new Downloader(new HttpClient()), new Uri(productUrl));
            //return crawler.Run(5);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public static void GetHtmlFromURL(string productUrl)
        {
            //full page
            //HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create("http://www.domain.com/");
            //HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
            //Stream response = WebResp.GetResponseStream();
            //StreamReader data = new StreamReader(response);
            //string result = data.ReadToEnd();

            //specific div from page
            //HtmlWeb web = new HtmlWeb();
            //HtmlDocument doc = web.Load("http://jsbin.com/owobe3");
            //HtmlNode rateNode = doc.DocumentNode.SelectSingleNode("//div[@id='rate']");
            //string rate = rateNode.InnerText;
        }

        internal static bool IsUserExists()
        {
            throw new NotImplementedException();
        }

        public static bool IsUserAuthorized(string user)
        {
            return true;
        }

        
    }

}
