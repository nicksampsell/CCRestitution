using Microsoft.AspNetCore.Mvc;

namespace CCRestitution.Areas.Payments.Controllers
{
    public class ReceiptController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
