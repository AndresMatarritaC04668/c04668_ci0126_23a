using Microsoft.AspNetCore.Mvc;
using Examen2.Models;
using Examen2.Handlers;

namespace Examen2.Controllers
{
    public class AutomovilController : Controller
    {
       private AutomovilHandler automovilHandler = new AutomovilHandler();

        [HttpGet]

        public IActionResult AdministrarAutomoviles()
        {
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

        [HttpGet]
        public ActionResult EditarAutomovil(string? marca, string? modelo)
        {
            ActionResult vista;
            try
            {
                var automovil = automovilHandler.ObtenerAutomoviles().Find(model => model.Marca == marca
                                                                           && model.Modelo == modelo);
                if ( automovil == null )
                {
                    vista = RedirectToAction("AdministrarAutomoviles");
                }
                else
                {
                    vista = View(automovil);
                }
            }
            catch
            {
                vista = RedirectToAction("AdministrarAutomoviles");
            }

            return vista;
        }

        [HttpPost]
        public ActionResult EditarAutomovil( AutomovilModel automovil )
        {
            try
            {
                automovilHandler.EditarAutomovil(automovil);
                return RedirectToAction("AdministrarAutomoviles" , "Automovil");

            }
            catch
            {
                ViewBag.Mensaje = "La modificacion del automóvil tuvo un error";
                return View();
            }
        }


        [HttpGet]
        public ActionResult EliminarAutomovil(string? marca , string? modelo)
        {
            ActionResult vista;

            try
            {       
                var automovil = automovilHandler.ObtenerAutomoviles().Find(model => model.Marca == marca
                                                                           && model.Modelo == modelo);
                if (modelo == null)
                {
                    vista = RedirectToAction("AdministrarAutomoviles");
                }
                else
                {
                    automovilHandler.EliminarAutomovil(automovil);
                    vista = RedirectToAction("AdministrarAutomoviles");
                }
            }
            catch
            {
                vista = RedirectToAction("AdministrarAutomoviles");
            }

            return vista;
        }

    }
}
