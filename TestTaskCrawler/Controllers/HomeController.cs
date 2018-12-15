﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestTaskCrawler.Models;
using TestTaskCrawler.LogicLayer;
using Microsoft.EntityFrameworkCore;
using TestTaskCrawler.DAL;

namespace TestTaskCrawler.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            //return View();
            return RedirectToAction("ResetPassword", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewData["Title"] = "Login";
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            ViewData["Title"] = "Login";

            if (ModelState.IsValid && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                
            }

            return View();
        }

        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(string UserName)
        {
            //if (ModelState.IsValid)
            //{
            //    //if (WebSecurity.UserExists(UserName))
            //    //{
            //    string To = UserName, UserID, Password, SMTPPort, Host;
            //    //string token = WebSecurity.GeneratePasswordResetToken(UserName);
            //    string token = "";
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
            //    //}
            //}

            return View();
        }


        //public ActionResult ResetPassword() //(string code, string email)
        //{
        //    //ResetPasswordModel model = new ResetPasswordModel();
        //    //model.ReturnToken = code;
        //    //return View(model);

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult ResetPassword(ResetPasswordModel model) //(string code, string email)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //bool resetResponse = WebSecurity.ResetPassword(model.ReturnToken, model.Password);
        //        //if (resetResponse)
        //        //{
        //        //    ViewBag.Message = "Successfully Changed";
        //        //}
        //        //else
        //        //{
        //        //    ViewBag.Message = "Something went horribly wrong!";
        //        //}
        //    }
        //    return View(model);
        //}

        //public ActionResult ForgotPassword(string UserName)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //if (WebSecurity.UserExists(UserName))
        //        //{
        //        //    string To = UserName, UserID, Password, SMTPPort, Host;
        //        //    string token = WebSecurity.GeneratePasswordResetToken(UserName);
        //        //    if (token == null)
        //        //    {
        //        //        // If user does not exist or is not confirmed.  

        //        //        return View("Index");

        //        //    }
        //        //    else
        //        //    {
        //        //        //Create URL with above token  

        //        //        var lnkHref = "<a href='" + Url.Action("ResetPassword", "Account", new { email = UserName, code = token }, "http") + "'>Reset Password</a>";


        //        //        //HTML Template for Send email  

        //        //        string subject = "Your changed password";

        //        //        string body = "<b>Please find the Password Reset Link. </b><br/>" + lnkHref;


        //        //        //Get and set the AppSettings using configuration manager.  

        //        //        EmailManager.AppSettings(out UserID, out Password, out SMTPPort, out Host);


        //        //        //Call send email methods.  

        //        //        EmailManager.SendEmail(UserID, subject, body, To, UserID, Password, SMTPPort, Host);

        //        //    }

        //        //}

        //    }
        //    return View();
        //}


        //public IActionResult SearchProduct(string emailUser,string productUrl)
        //public IActionResult SearchProduct(Account user, string productUrl)
        [HttpPost]
        public IActionResult SearchProduct(string ProductUrl)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(ProductUrl))
            {
                Crawler.GetProductDetailsByUrl(ProductUrl);
                return View();
            }

            return View();
        }

        [HttpGet]
        public ActionResult ShowAllProducts()
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFContextDB>();
            optionsBuilder.UseSqlServer("Data Source=TestTaskCrawlerDB");

            var entities = new EFContextDB(optionsBuilder.Options).Products.;

            return View(entities.Products.ToList());
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(Account user)
        {
            ViewData["Title"] = "Signup";

            if (ModelState.IsValid)
            {
                var NewUser = HelperFunctions.AddUser(user);

                if (NewUser != null)
                {
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
