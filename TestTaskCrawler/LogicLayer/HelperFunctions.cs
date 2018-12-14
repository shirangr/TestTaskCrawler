using TestTaskCrawler.DAL;
using TestTaskCrawler.Models;
using System;

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
                if ((user == null) || (user.Email == null))
                {
                    return null;
                }

                using (var db = new EFContextDB())
                {
                    // Create and save a new user
                    var firsttimeloggedin = DateTime.Now;
                    var NewUser = new Account { Email = user.Email, Password = user.Password, FirstTimeLoggedIn = firsttimeloggedin };
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

        public static bool IsUserAuthorized(string user)
        {
            return true;
        }
    }

}
