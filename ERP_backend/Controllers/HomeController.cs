using Microsoft.AspNetCore.Mvc;

namespace ERP_backend.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
