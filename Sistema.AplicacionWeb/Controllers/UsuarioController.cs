using Microsoft.AspNetCore.Mvc;

namespace Sistema.AplicacionWeb.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
