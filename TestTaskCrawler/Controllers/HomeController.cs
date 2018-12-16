using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestTaskCrawler.Models;
using TestTaskCrawler.LogicLayer;
using Microsoft.EntityFrameworkCore;
using TestTaskCrawler.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace TestTaskCrawler.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
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


        [HttpGet]
        public IActionResult SearchProduct()
        {
            ViewData["Title"] = "Search Product";

            //get all products
            //example

            ViewBag.Username = "shirangrosu@gmail.com";
            //var allproducts = HelperFunctions.GetAllProducts(ViewBag.Username);

            //if (allproducts != null)
            //{
            //    return View(allproducts);
            //}

            return View();

        }

        [HttpPost]
        public IActionResult SearchProduct(string ProductUrl)
        {
            //get product
            if (ModelState.IsValid && !string.IsNullOrEmpty(ProductUrl))
            {
                return View();
            }
            
            return View();
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


    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly EFContextDB _context;


        public ProductsController(EFContextDB context)
        {
            _context = context;
        }

        [HttpGet]
        //[Produces(typeof(List<Product>))]
        public async Task<ActionResult<ICollection<Product>>> GetAllProducts()
        {
            //return await _context.Products.ToListAsync();
            //return await _context.Products.ToList<Product>();

            return null;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductDetailsByUrl(long id)
        {
            //var result = await _context.Products.FindAsync(id);

            //if (result == null)
            //{
            //    return NotFound();
            //}

            //return result;

            return null;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> addProductAsync(Product product)
        {
            _context.Products.Append<Product>(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductDetailsByUrl", new { id = product.ID }, product);
        }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        //public static List<Product> GetAllProducts(string username)
        //{
        //    try
        //    {
        //        List<Product> allproducts = null;

        //        var optionsBuilder = new DbContextOptionsBuilder<EFContextDB>();
        //        optionsBuilder.UseSqlServer("Server=.;Database=TestTaskCrawler.EFContextDB;Trusted_Connection=True;MultipleActiveResultSets=true");

        //        //add new
        //        using (var context = new EFContextDB(optionsBuilder.Options))
        //        {
        //            if (context.Products != null)
        //            {
        //                var query = from x in context.Products
        //                            where x.Username == username
        //                            orderby x.Name
        //                            select x;

        //                //var query = context.Products.FromSql("SELECT * FROM Products WHERE username=@p0 order by Name Asc", new object[] { username });

        //                if (query != null)
        //                {
        //                    allproducts = query.ToList<Product>();
        //                }
        //            }

        //            return allproducts;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //        throw ex;
        //    }

        //}
    }
}
