using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAspNetCoreApp.Web.Helpers;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductsController : Controller
    {

        private AppDbContext _context;
        private readonly ProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(AppDbContext context, IMapper mapper)
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
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            var products = _context.Products.ToList();

            return View(_mapper.Map<List<ProductViewModel>>(products));
        }

        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);

            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1},
                {"3 Ay",3},
                {"6 Ay",6},
                {"12 Ay",12}
            };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList> {
                new(){Data="Blue",Value="Blue"},
                new(){Data="Green",Value="Green"},
                new(){Data="Red",Value="Red"}
            }, "Value", "Data");


            return View();
        }

        [HttpPost]
        public IActionResult Add(Product newProduct)
        {
            _context.Products.Add(newProduct);
            _context.SaveChanges();

            TempData["status"] = "Added successfully!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);

            ViewBag.ExpireValue = product.Expire;
            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1},
                {"3 Ay",3},
                {"6 Ay",6},
                {"12 Ay",12}
            };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList> {
                new(){Data="Blue",Value="Blue"},
                new(){Data="Green",Value="Green"},
                new(){Data="Red",Value="Red"}
            }, "Value", "Data",product.Color);

            
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product updateProduct, int productId)
        {
            updateProduct.Id = productId;
            _context.Products.Update(updateProduct);
            _context.SaveChanges();

            TempData["status"] = "Updated successfully!";
            return RedirectToAction("Index");
        }

    }
}
