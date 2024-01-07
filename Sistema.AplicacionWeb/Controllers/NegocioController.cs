using Microsoft.AspNetCore.Mvc;

namespace Sistema.AplicacionWeb.Controllers
{
    public class NegocioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
