using Microsoft.AspNetCore.Mvc;

namespace Sistema.AplicacionWeb.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
