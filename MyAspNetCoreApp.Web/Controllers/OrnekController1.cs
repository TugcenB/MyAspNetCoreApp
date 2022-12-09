using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class Product2
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class OrnekController : Controller
    {

        public IActionResult Index()
        {
            var products = new List<Product2>()
            {
                new(){Id=1,Name="kalem"},
                new(){Id=2,Name="silgi"},
                new(){Id=3,Name="defter"}
            };
            ViewBag.name = "Asp.Net Core";

            ViewData["age"] = 26;
            ViewData["names"] = new List<string>() { "ahmet", "mehmet", "süreyya" };

            TempData["surname"] = "bilgin";

            return View(products);
        }

        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult Index3()
        {
            return RedirectToAction("Index","Ornek");
        }

        public IActionResult ParametreView(int id)
        {
            return RedirectToAction("JsonResultParametre", "Ornek", new { id = id });
        }

        public IActionResult JsonResultParametre(int id)
        {
            return Json(new { Id = id});
        }
        public IActionResult ContentResult()
        {
            return Content("Content Result");
        }

        public IActionResult JsonResult()
        {
            return Json(new {Id=1, name="kalem", price=50});
        }
        public IActionResult EmptyResult()
        {
            return new EmptyResult();
        }
    }
}
