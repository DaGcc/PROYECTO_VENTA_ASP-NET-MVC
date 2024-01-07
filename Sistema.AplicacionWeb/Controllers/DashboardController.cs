using Microsoft.AspNetCore.Mvc;

namespace Sistema.AplicacionWeb.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
