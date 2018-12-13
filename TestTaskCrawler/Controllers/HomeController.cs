using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestTaskCrawler.Models;

namespace TestTaskCrawler.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Login()
        {
            ViewData["Title"] = "Login";
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            //try
            //{

            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            ViewData["Title"] = "Login";

            if ((ModelState.IsValid) && (username.Trim().Length > 0 && password.Trim().Length > 0))
            {
                //check if user exists
                //var account = from x in _context.Account
                //              where x.Username == username
                //              && x.password == password
                //              select x;

                //if (results.count>0) //results.username!=null
                //{ 
                //save to db
                //account.username = username;

                //if (account.FirstTimeLoggedIn == null)
                //{
                //    var firsttimeloggedin = DateTime.UtcNow;
                //}

                //account.lastloggedin = DateTime.UtcNow;

                //    return RedirectToAction("SearchProduct", "Home");
                //}
            }

            return View();
        }

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

        public IActionResult SearchProduct()
        {
            ViewData["Title"] = "SearchProduct";
            return View();
        }


        //public IActionResult SearchProduct(string emailUser,string productAddress)
        //public IActionResult SearchProduct(Account user, string productAddress)
        [HttpGet]
        public IActionResult SearchProduct(string productAddress)
        {
            //check if already exists
            //var productExistsDetails = from x in _context.Product
            //                           where x.Username == user.Username
            //                           && x.password == user.Password
            //                           select x;

            //if (productExistsDetails.count > 0) //results.username!=null
            //{
            //    return View(productExistsDetails.tolist());
            //}

            //var productSearchedDetails = GetProductDetailsByAddress(productAddress);
            //if (productSearchedDetails != null)
            //{
            //    return View(productSearchedDetails.tolist());
            //}

            return View();
        }


        public IActionResult Signup()
        {
            ViewData["Title"] = "Signup";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
