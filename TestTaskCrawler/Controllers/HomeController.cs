using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTaskCrawler.Models;
using TestTaskCrawler.DAL;


namespace TestTaskCrawler.Controllers
{
    public class HomeController : Controller
    {

      

        public IActionResult Login()
        {
            ViewData["Title"] = "Login";

            try
            {
                if (ModelState.IsValid)
                {
                    //    if (true) //new user
                    //    {
                    //        if (model.FirstTimeLoggedIn == null)
                    //        {
                    //            var firsttimeloggedin = DateTime.UtcNow;
                    //        }

                    //        var lastloggedin = DateTime.UtcNow;

                    //        var username = model.Username;

                    //        //save to db


                    //        return RedirectToAction("SearchProduct");
                    //    }

                }

                //return RedirectToAction("Signup");
                return View();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public IActionResult ResetPassword()
        {
            ViewData["Title"] = "ResetPassword";
            return View();
        }

        public IActionResult SearchProduct()
        {
            ViewData["Title"] = "SearchProduct";
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

        //// POST: /Account/Login
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Login(Account model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //if (_context.Users.Contains(model.UserName))//Errors out here
        //        //{
        //        //    var user = new Account { Username = model.Username };
        //        //    user.Username = model.Username;
        //        //    var result = await UserManager.CreateAsync(user, model.Password);
        //        //    if (result.Succeeded)
        //        //    {
        //        //        await this.UserManager.AddToRoleAsync(user.Id, model.Name);
        //        //        return RedirectToAction("Index", "User");
        //        //    }
        //        //    AddErrors(result);
        //        //}
        //    }
        //    return View(model);
        //}

        //// POST: /Account/Register
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public IActionResult Login(Account model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //if (_context.Users.Contains(model.UserName))//Errors out here
        //        //{
        //        //    var user = new Account { Username = model.Username };
        //        //    user.Username = model.Username;
        //        //    var result = await UserManager.CreateAsync(user, model.Password);
        //        //    if (result.Succeeded)
        //        //    {
        //        //        await this.UserManager.AddToRoleAsync(user.Id, model.Name);
        //        //        return RedirectToAction("Index", "User");
        //        //    }
        //        //    AddErrors(result);
        //        //}
        //    }
        //    return View(model);
        //}


        /// <summary>
        /// gets account by given email address
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetUserByEmail(string Address)
        {
            //if (Address.Trim().Length > 0 && Address != null)
            //{
            //    var users = await _context.Users
            //    .Include(u => u.Username)
            //    .ToArrayAsync();

            //    var response = users.Select(u => new
            //    {
            //        username = u.Username,
            //        password = u.Password
            //    });

            //    return Ok(response);
            //}
            //else
            //{
            //    return ;
            //}
            return Ok();
        }

        //public async Task<ActionResult> GetProductByAddress(string Address)
        //{
        //    if (Address.Trim().Length > 0 && Address != null)
        //    {
        //        var users = await _context.Users
        //        .Include(u => u.Username)
        //        .ToArrayAsync();

        //        var response = users.Select(u => new
        //        {
        //            username = u.Username,
        //            password = u.Password
        //        });

        //        return Ok(response);
        //    }
        //    else
        //    {
        //        return Ok();
        //    }

        //}

    }
}
