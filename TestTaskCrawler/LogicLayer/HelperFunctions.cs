using TestTaskCrawler.DAL;
using TestTaskCrawler.Models;
using TestTaskCrawler.LogicLayer;
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
        public static int AddUser(Account user)
        {
            Account usr = new Account() { Username = user.Username, Password = user.Password };
            int result = 0;

            try
            {
                using (EFContext ctx = new EFContext())
                {
                    ctx.Accounts.Add(usr);
                    result = ctx.SaveChanges();
                }

                return result;
            }
            catch (Exception ex)
            {
                return result;
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

        public static bool IsUserAuthorized(Account user)
        {
            return true;

        }
    }
}
