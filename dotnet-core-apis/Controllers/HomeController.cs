using Microsoft.AspNetCore.Mvc;

namespace dotnet_core_apis.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}