using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Article()
        {
            var routes = Request.RouteValues["article"];

            return View();
        }
    }
}
