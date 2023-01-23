using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductsController : Controller
    {

        private AppDbContext _context;
        private readonly ProductRepository _productRepository;

        public ProductsController(AppDbContext context)
        {
            _productRepository = new ProductRepository();

            _context = context;

            if (!_context.Products.Any())
            {
                _context.Products.Add(new Product() { Name = "Kalem 1", Stock = 10, Price = 100, Color = "Red" });
                _context.Products.Add(new Product() { Name = "Kalem 2", Stock = 10, Price = 200, Color = "White" });
                _context.Products.Add(new Product() { Name = "Kalem 3", Stock = 10, Price = 300, Color = "Red" });

                _context.SaveChanges();
            }


        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();

            return View(products);
        }

        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);

            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SaveProduct(Product newProduct)
        {
            //Request Header-Body

            //Method 1
            //var name = HttpContext.Request.Form["Name"].ToString();
            //var price = decimal.Parse(HttpContext.Request.Form["Price"].ToString());
            //var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());
            //var color= HttpContext.Request.Form["Color"].ToString();

            //Method 2
            //Product newProduct = new Product(){Name=Name,Color=Color,Stock=Stock,Price=Price };
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return View("SaveProduct");
        }
        public IActionResult Update(int id)
        {
            return View();
        }

    }
}
