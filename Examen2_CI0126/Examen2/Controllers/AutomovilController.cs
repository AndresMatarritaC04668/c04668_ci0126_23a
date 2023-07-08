using Microsoft.AspNetCore.Mvc;
using Examen2.Models;
namespace Examen2.Controllers
{
    public class AutomovilController : Controller
    {
        [HttpGet]
        public IActionResult AgregarAutomovil()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AgregarAutomovil(AutomovilModel automovil)
        {
            return View();
        }
    }
}
