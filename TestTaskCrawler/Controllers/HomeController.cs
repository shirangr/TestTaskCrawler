using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestTaskCrawler.Models;
using TestTaskCrawler.LogicLayer;
using TestTaskCrawler.DAL;

namespace TestTaskCrawler.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly EFContextDB _context;

        public HomeController(EFContextDB context)
        {
            _context = context;
        }

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

            //ViewBag.Username = "shirangrosu@gmail.com";
            return View();

        }

        [HttpPost]
        public IActionResult SearchProduct(string ProductUrl)
        {
            //get product
            if (ModelState.IsValid && !string.IsNullOrEmpty(ProductUrl))
            {
                //Product product = ProductsController.GetProductDetailsByUrl(ProductUrl);
                ////ViewBag.username = "shirangrosu@gmail.com";

                //ProductsController proc = new ProductsController(_context);
                //var request = proc.addProductAsync(product);

                //return View(request);
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


    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly EFContextDB _context;

        public ProductsController(EFContextDB context)
        {
            _context = context;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        //{
        //    return await Task.Run(() => _context.Products.ToList<Product>());
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Product>> GetProductDetailsById(long id)
        //{
        //    var Id = (int)id;
        //    var result = await Task.Run(() => _context.Products.FirstOrDefault<Product>(m => m.ID == Id));

        //    if (result == null)
        //    {
        //        return NotFound();
        //    }

        //    return result;
        //}

        ////[HttpPost]
        ////public async Task<ActionResult<Product>> addProductAsync(Product product)
        ////{
        ////    _context.Products.Append<Product>(product);
        ////    await _context.SaveChangesAsync();

        ////    return CreatedAtAction("GetProductDetailsByUrl", new { id = product.ID }, product);
        ////}

        //[HttpPost]
        //public async Task<ActionResult<Product>> addProductAsync([FromBody]Product product)
        //{
        //    _context.Products.Append<Product>(product);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetProductDetailsById", "Products", new { id = product.ID }, product);
        //}

        //public static Product GetProductDetailsByUrl(string ProductUrl)
        //{
        //    try
        //    {
        //        //TODO: each website has an Encoding. get encoding by attribute charset
        //        //<html head meta charset=> encoding
        //        //<style - body - background-color> background color of current html page

        //        //Uri ProductUri = new Uri(ProductUrl);

        //        WebClient client = new WebClient();
        //        HtmlDocument doc = new HtmlDocument();
        //        String html = client.DownloadString(ProductUrl);
        //        html = html.Replace("<br>", "\r\n"); // Replace all html breaks for line seperators.
        //        doc.LoadHtml(html);

        //        //Get data
        //        string Title = doc.DocumentNode.SelectNodes("//h1[@itemprop='name']").First().InnerHtml;
        //        string Description = doc.DocumentNode.SelectNodes("//div[@id='Description']").First().InnerHtml;
        //        char[] charsToTrim = { '₪' };
        //        decimal Price = Decimal.Parse(doc.DocumentNode.SelectNodes("//span[@class='price']").First().InnerHtml.Trim(charsToTrim).Trim());
        //        string Image = doc.DocumentNode.SelectNodes("//img[@class='cloudzoom']").First().InnerHtml;
        //        string BackgroundPageColor = doc.DocumentNode.SelectNodes("//img[@class='cloudzoom']").First().InnerHtml;

        //        var optionsBuilder = new DbContextOptionsBuilder<EFContextDB>();
        //        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WebApplicationCrawler.ApplicationDbContext;Trusted_Connection=True;MultipleActiveResultSets=true");


        //        Product product = new Product { ProductURL = ProductUrl, Name = Title, Description = Description, Condition = "not available", Price = Price, ShippingPrice = 0, ImagePath = Image, BackgroundPageColor = "" };
        //        return product;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

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
