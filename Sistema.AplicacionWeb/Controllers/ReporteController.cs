using Microsoft.AspNetCore.Mvc;

namespace Sistema.AplicacionWeb.Controllers
{
    public class ReporteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
