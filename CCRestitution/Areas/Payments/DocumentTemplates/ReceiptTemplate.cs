using Microsoft.AspNetCore.Mvc;

namespace CCRestitution.Areas.Payments.DocumentTemplates
{
    public class ReceiptTemplate : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
