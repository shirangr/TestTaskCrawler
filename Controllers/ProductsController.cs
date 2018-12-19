using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestTaskCrawler.Data;
using TestTaskCrawler.Models;

namespace TestTaskCrawler.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly EFContextDB _context;

        
        public ProductsController(EFContextDB context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProductURL,Name,Description,Condition,Price,ShippingPrice,ImagePath,BackgroundPageColor")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProductURL,Name,Description,Condition,Price,ShippingPrice,ImagePath,BackgroundPageColor")] Product product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
    }

    //[Route("api/[controller]/[action]")]
    //[ApiController]
    //public class ProductsController : ControllerBase
    //{
    //    //private readonly EFContextDB _context;

    //    //public ProductsController(EFContextDB context)
    //    //{
    //    //    _context = context;
    //    //}

    //    //[HttpGet]
    //    //public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
    //    //{
    //    //    return await Task.Run(() => _context.Products.ToList<Product>());
    //    //}

    //    //[HttpGet("{id}")]
    //    //public async Task<ActionResult<Product>> GetProductDetailsById(long id)
    //    //{
    //    //    var Id = (int)id;
    //    //    var result = await Task.Run(() => _context.Products.FirstOrDefault<Product>(m => m.ID == Id));

    //    //    if (result == null)
    //    //    {
    //    //        return NotFound();
    //    //    }

    //    //    return result;
    //    //}

    //    ////[HttpPost]
    //    ////public async Task<ActionResult<Product>> addProductAsync(Product product)
    //    ////{
    //    ////    _context.Products.Append<Product>(product);
    //    ////    await _context.SaveChangesAsync();

    //    ////    return CreatedAtAction("GetProductDetailsByUrl", new { id = product.ID }, product);
    //    ////}

    //    //[HttpPost]
    //    //public async Task<ActionResult<Product>> addProductAsync([FromBody]Product product)
    //    //{
    //    //    _context.Products.Append<Product>(product);
    //    //    await _context.SaveChangesAsync();

    //    //    return CreatedAtAction("GetProductDetailsById", "Products", new { id = product.ID }, product);
    //    //}

    //    public static Product GetProductDetailsByUrl(string ProductUrl)
    //    {
    //        try
    //        {
    //            //TODO: each website has an Encoding. get encoding by attribute charset
    //            //<html head meta charset=> encoding
    //            //<style - body - background-color> background color of current html page

    //            //Uri ProductUri = new Uri(ProductUrl);

    //            WebClient client = new WebClient();
    //            HtmlDocument doc = new HtmlDocument();
    //            String html = client.DownloadString(ProductUrl);
    //            html = html.Replace("<br>", "\r\n"); // Replace all html breaks for line seperators.
    //            doc.LoadHtml(html);

    //            //Get data
    //            string Title = doc.DocumentNode.SelectNodes("//h1[@itemprop='name']").First().InnerHtml;
    //            string Description = doc.DocumentNode.SelectNodes("//div[@id='Description']").First().InnerHtml;
    //            char[] charsToTrim = { '¤' };
    //            decimal Price = Decimal.Parse(doc.DocumentNode.SelectNodes("//span[@class='price']").First().InnerHtml.Trim(charsToTrim).Trim());
    //            string Image = doc.DocumentNode.SelectNodes("//img[@class='cloudzoom']").First().InnerHtml;
    //            string BackgroundPageColor = doc.DocumentNode.SelectNodes("//img[@class='cloudzoom']").First().InnerHtml;

    //            Product product = new Product { ProductURL = ProductUrl, Name = Title, Description = Description, Condition = "not available", Price = Price, ShippingPrice = 0, ImagePath = Image, BackgroundPageColor = "" };
    //            return product;

    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }

    //    }

    //    /// <summary>
    //    /// Gets all products
    //    /// </summary>
    //    /// <param name="user"></param>
    //    /// <returns></returns>
    //    //public static List<Product> GetAllProducts(string username)
    //    //{
    //    //    try
    //    //    {
    //    //        List<Product> allproducts = null;

    //    //        var optionsBuilder = new DbContextOptionsBuilder<EFContextDB>();
    //    //        optionsBuilder.UseSqlServer("Server=.;Database=TestTaskCrawler.EFContextDB;Trusted_Connection=True;MultipleActiveResultSets=true");

    //    //        //add new
    //    //        using (var context = new EFContextDB(optionsBuilder.Options))
    //    //        {
    //    //            if (context.Products != null)
    //    //            {
    //    //                var query = from x in context.Products
    //    //                            where x.Username == username
    //    //                            orderby x.Name
    //    //                            select x;

    //    //                //var query = context.Products.FromSql("SELECT * FROM Products WHERE username=@p0 order by Name Asc", new object[] { username });

    //    //                if (query != null)
    //    //                {
    //    //                    allproducts = query.ToList<Product>();
    //    //                }
    //    //            }

    //    //            return allproducts;
    //    //        }

    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        return null;
    //    //        throw ex;
    //    //    }

    //    //}


    //}
}
