using Microsoft.AspNetCore.Mvc;
using Examen2.Models;
using Examen2.Handlers;

namespace Examen2.Controllers
{
    public class AutomovilController : Controller
    {
        [HttpGet]

        public IActionResult AdministrarAutomoviles()
        {
           AutomovilHandler automovilHandler = new AutomovilHandler();
            var automoviles = automovilHandler.ObtenerAutomoviles();
            ViewBag.MainTitle = "Lista de automóviles";
            return View(automoviles);
        }

        [HttpGet]
        public IActionResult AgregarAutomovil()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AgregarAutomovil(AutomovilModel automovil)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                   AutomovilHandler automovilHandler = new AutomovilHandler();
                   ViewBag.ExitoAlCrear = automovilHandler.AgregarAutomovil(automovil);

                    if (ViewBag.ExitoAlCrear)
                    {
                        ViewBag.Message = "El automóvil " + automovil.Marca + 
                                            " " + automovil.Modelo + " fue agregado con éxito.";
                        ModelState.Clear();
                    } else
                    {
                        ViewBag.Message = "Algo salió mal y no fue posible agregar el  automóvil ";
                        return View();
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salió mal y no fue posible agregar el  automóvil ";
                return View();
            } 
        }

    }
}
