using TestTaskCrawler.DAL;
using TestTaskCrawler.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HtmlAgilityPack;
using System.Net;

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
                optionsBuilder.UseSqlServer("Data Source=TestTaskCrawler.EFContextDB");

                using (var db = new EFContextDB(optionsBuilder.Options))
                {
                    // Create and save a new user
                    var NewUser = new Account { Username = user.Username, Password = user.Password };
                    db.Accounts.Append<Account>(NewUser);
                    db.SaveChanges();

                    return NewUser;
                }


            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }

}


public class Crawler
{
    /// <summary>
    /// Gets product details by given url address
    /// </summary>
    /// <param name="ProductUrl"></param>
    /// <example>https://toysrus.co.il/%D7%91%D7%A0%D7%95%D7%AA/%D7%91%D7%A8%D7%91%D7%99-%D7%91%D7%AA-%D7%94%D7%99%D7%9D-%D7%A6%D7%91%D7%A2%D7%99-%D7%94%D7%A7%D7%A9%D7%AA.html</example>
    public static Product GetProductDetailsByUrl(string ProductUrl)
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

            Product product = new Product { ProductURL = ProductUrl, Name = Title, Description = Description, Condition = "not available", Price = Price, ShippingPrice = 0, ImagePath = Image, BackgroundPageColor = "" };

            return product;

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

}
