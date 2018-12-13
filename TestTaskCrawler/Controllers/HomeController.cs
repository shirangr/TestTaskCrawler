using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestTaskCrawler.Models;
using TestTaskCrawler.DAL;
using TestTaskCrawler.LogicLayer;

namespace TestTaskCrawler.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            ViewData["Title"] = "Login";
            return View();
        }

        [HttpPost]
        public IActionResult Login(Account user)
        {
            ViewData["Title"] = "Login";

            if (ModelState.IsValid && !string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Password))
            {
                using (var ctx = new EFContext())
                {
                    //DbCollectionEntry results = from x in dbo.Accounts
                    //                              where x.Username == user.Username
                    //                              && x.password == user.Password
                    //                              select x;

                    //ctx.Users.SqlQuery("SELECT * FROM dbo.Account WHERE username=@p0 and password=@p1", new params object user.Username);


                    //if (results.count>0) //results.username!=null
                    //{ 
                    //save to db
                    //account.username = username;

                    //if (account.FirstTimeLoggedIn == null)
                    //{
                    //    var firsttimeloggedin = DateTime.UtcNow;
                    //}

                    //account.lastloggedin = DateTime.UtcNow;

                    //ctx.SaveChanges();

                    //    return RedirectToAction("SearchProduct", "Home");
                    //}
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            ViewData["Title"] = "ResetPassword";
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(string UserName)
        {
            if (ModelState.IsValid)
            {

                //if (WebSecurity.UserExists(UserName))
                //{
                //    string To = UserName, UserID, Password, SMTPPort, Host;
                //    string token = WebSecurity.GeneratePasswordResetToken(UserName);
                //    if (token == null)
                //    {
                //        // If user does not exist or is not confirmed.  

                //        return View("Index");

                //    }
                //    else
                //    {
                //        //Create URL with above token  

                //        var lnkHref = "<a href='" + Url.Action("ResetPassword", "Account", new { email = UserName, code = token }, "http") + "'>Reset Password</a>";


                //        //HTML Template for Send email  

                //        string subject = "Your changed password";

                //        string body = "<b>Please find the Password Reset Link. </b><br/>" + lnkHref;


                //        //Get and set the AppSettings using configuration manager.  

                //        EmailManager.AppSettings(out UserID, out Password, out SMTPPort, out Host);


                //        //Call send email methods.  

                //        EmailManager.SendEmail(UserID, subject, body, To, UserID, Password, SMTPPort, Host);

                //    }

                //}

            }


            return View();
        }


        //public IActionResult SearchProduct(string emailUser,string productUrl)
        //public IActionResult SearchProduct(Account user, string productUrl)
        [HttpPost]
        public IActionResult SearchProduct(string productUrl)
        {
            if (ModelState.IsValid)
            {
                //using (var ctx = new EFContext())
                //{
                //    //check if already exists
                //    var productExistsDetails = (from x in ctx.Products
                //                                where x.productUrl == productUrl
                //                                orderby x.date
                //                                select x).ToList(); 

                //}
                //if (productExistsDetails.count > 0) //results.username!=null
                //{
                //    return View(productExistsDetails.tolist());
                //}

                //var productSearchedDetails = GetProductDetailsByAddress(productUrl);
                //if (productSearchedDetails != null)
                //{
                //    return View(productSearchedDetails.tolist());
                //}

            }

            return View();
        }

        [HttpPost]
        public IActionResult Signup(Account user)
        {
            ViewData["Title"] = "Signup";
            int AddedUser = 0;

            if (ModelState.IsValid)
            {
                if (user != null && !string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Password))
                {
                    AddedUser = HelperFunctions.AddUser(user);
                }

                if (AddedUser != 0)
                {
                    //ViewBag.Username = Request["username"].ToString();
                    //ViewBag.Password = Request["password"].ToString();
                    return RedirectToAction("Login", "Home");
                }
            }


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
