using TestTaskCrawler.DAL;

namespace TestTaskCrawler.LogicLayer
{
    public class HelperFunctions
    {
        /// <summary>
        /// returns product details from db/from web
        /// </summary>
        /// <param name="productAddress"></param>
        public void GetProductDetailsByAddress(string productAddress)
        {
            //var crawler = new WebCrawler(new Downloader(new HttpClient()), new Uri(productAddress));
            //return crawler.Run(5);
        }

        /// <summary>
        /// adding data to db
        /// </summary>
        /// <param name="context"></param>
        public static void AddTestData(ApplicationDbContext context)
        {
            //var testUser1 = new DbModels.User
            //{
            //    Id = "abc123",
            //    FirstName = "Luke",
            //    LastName = "Skywalker"
            //};

            //context.Users.Add(testUser1);

            //var testPost1 = new DbModels.Post
            //{
            //    Id = "def234",
            //    UserId = testUser1.Id,
            //    Content = "What a piece of junk!"
            //};

            //context.Posts.Add(testPost1);

            //context.SaveChanges();
        }

        public void GetHtmlFromURL(string url)
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
    }
}
