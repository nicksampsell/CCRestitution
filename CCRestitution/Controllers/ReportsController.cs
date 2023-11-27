using Microsoft.AspNetCore.Mvc;

namespace CCRestitution.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
