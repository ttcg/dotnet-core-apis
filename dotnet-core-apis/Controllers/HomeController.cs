using dotnet_core_apis.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet_core_apis.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _log;
        private SecondLevelClass _secondLevelClass;

        public HomeController(
            ILogger<HomeController> log,
            SecondLevelClass secondLevelClass)
        {
            _log = log;
            _secondLevelClass = secondLevelClass;
        }

        public IActionResult Index()
        {
            _log.LogInformation("Index");
            _secondLevelClass.TestMethod();
            return View();
        }
    }
}