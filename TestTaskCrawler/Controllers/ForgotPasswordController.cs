using Microsoft.AspNetCore.Mvc;

namespace TestTaskCrawler.Controllers
{
    public class ForgotPasswordController : Controller
    {
        public ActionResult ResetPassword()
        {
            ViewData["Title"] = "Reset Password";
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(string UserName)
        {
            ViewData["Title"] = "Reset Password";

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
    }
}