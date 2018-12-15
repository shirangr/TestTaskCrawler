using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using TestTaskCrawler.DAL;
using TestTaskCrawler.Models;

namespace TestTaskCrawler.LogicLayer
{
    public class Crawler
    {
        /// <summary>
        /// Gets product details by given url address
        /// </summary>
        /// <param name="ProductUrl"></param>
        /// <example>https://toysrus.co.il/%D7%91%D7%A0%D7%95%D7%AA/%D7%91%D7%A8%D7%91%D7%99-%D7%91%D7%AA-%D7%94%D7%99%D7%9D-%D7%A6%D7%91%D7%A2%D7%99-%D7%94%D7%A7%D7%A9%D7%AA.html</example>
        public static void GetProductDetailsByUrl(string ProductUrl)
        {
            try
            {
                //TODO: each website has an Encoding. get encoding by attribute charset
                //<html head meta charset=> encoding
                //<style - body - background-color> background color of current html page

                //Uri ProductUri = new Uri(ProductUrl);

                WebClient client = new WebClient();
                HtmlDocument doc = new HtmlDocument();
                String html = client.DownloadString(ProductUrl);
                html = html.Replace("<br>", "\r\n"); // Replace all html breaks for line seperators.
                doc.LoadHtml(html);

                //Get data
                string Title = doc.DocumentNode.SelectNodes("//h1[@itemprop='name']").First().InnerHtml;
                string Description = doc.DocumentNode.SelectNodes("//div[@id='Description']").First().InnerHtml;
                char[] charsToTrim = { '₪' };
                decimal Price = Decimal.Parse(doc.DocumentNode.SelectNodes("//span[@class='price']").First().InnerHtml.Trim(charsToTrim).Trim());
                string Image = doc.DocumentNode.SelectNodes("//img[@class='cloudzoom']").First().InnerHtml;
                string BackgroundPageColor = doc.DocumentNode.SelectNodes("//img[@class='cloudzoom']").First().InnerHtml;

                var optionsBuilder = new DbContextOptionsBuilder<EFContextDB>();
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestTaskCrawler.EFContextDB;Trusted_Connection=True;MultipleActiveResultSets=true");

                //add new
                using (var context = new EFContextDB(optionsBuilder.Options))
                {
                    Product pro = new Product { ProductURL = ProductUrl, Name = Title, Description = Description, Condition = "not available", Price = Price, ShippingPrice = 0, ImagePath = Image, BackgroundPageColor = "" };
                    context.Add(pro);
                    context.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
