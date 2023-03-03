﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAspNetCoreApp.Web.Filters;
using MyAspNetCoreApp.Web.Helpers;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.Controllers
{

    [Route("[controller]/[action]")]
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


        //[HttpGet("{page}/{pageSize}")]

        [Route("[controller]/[action]/{page}/{pageSize}", Name ="productpage")]
        public IActionResult Pages(int page,int pageSize)
        {
            var products = _context.Products.Skip((page-1)*pageSize).Take(pageSize).ToList();
            
            ViewBag.page = page;
            ViewBag.pageSize = pageSize;

            return View(_mapper.Map<List<ProductViewModel>>(products));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [Route("[controller]/[action]/{productId}", Name ="product")]
        public IActionResult GetById(int productId)
        {
            var product = _context.Products.Find(productId);

            return View(_mapper.Map<ProductViewModel>(product));

        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
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
        public IActionResult Add(ProductViewModel newProduct)
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
                

            //if (string.IsNullOrEmpty(newProduct.Name) && newProduct.Name.StartsWith("A"))
            //{
            //    ModelState.AddModelError(string.Empty,"Ürün A harfi ile başlayamaz!");
            //}

            if (ModelState.IsValid)
            {
                try
                {
                   
                    _context.Products.Add(_mapper.Map<Product>(newProduct));
                    _context.SaveChanges();

                    TempData["status"] = "Added successfully!";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    ModelState.AddModelError(String.Empty,"Ürün kaydedilirken bir hata meydana geldi. Lütfen daha sonra tekrar deneyiniz. ");
                    return View();

                }
                
            }

            else
            {
                return View();
            }
        }

        [ServiceFilter(typeof(NotFoundFilter))]
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
            }, "Value", "Data", product.Color);


            return View(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel updateProduct)
        {
 
            if (!ModelState.IsValid)
            {
                ViewBag.ExpireValue = updateProduct.Expire;
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
            }, "Value", "Data", updateProduct.Color);

                return View();
            }
            
            _context.Products.Update(_mapper.Map<Product>(updateProduct));
            _context.SaveChanges();

            TempData["status"] = "Updated successfully!";
            return RedirectToAction("Index");
        }


        [AcceptVerbs("GET","POST")]
        public IActionResult HasProductName(string Name) 
        {
            var anyProducts = _context.Products.Any(x => x.Name.ToLower() == Name.ToLower());

            if (anyProducts)
            {
                return Json("Kaydetmeye çalıştığınız ürün veri tabanında bulunmaktadır.");
            }
            else
            {
                return Json(true);
            }
        }
    }
}
