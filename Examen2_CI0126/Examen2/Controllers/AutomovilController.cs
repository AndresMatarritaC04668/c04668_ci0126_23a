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
                    TempData["marca"] = marca;
                    TempData["modelo"] =  modelo;
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
        public ActionResult EditarAutomovil(AutomovilModel automovil)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AutomovilModel automovilAEditar = new AutomovilModel();
                    automovilAEditar.Marca = (string)TempData["marca"];
                    automovilAEditar.Modelo = (string)TempData["modelo"];
                    automovilHandler.EditarAutomovil(automovil, automovilAEditar);
                    return RedirectToAction("AdministrarAutomoviles", "Automovil");
                }
                catch (Exception ex)
                {
                    throw new Exception("La modificación del automóvil tuvo un error: " + ex.Message);
                }
            }
            else
            {
                return View(automovil);
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

        public ActionResult AdministrarAutomovilesPorMarca(string? marca)
        {
            List<AutomovilModel> automoviles = automovilHandler.ObtenerAutomovilesPorMarca(marca);
            return View("AdministrarAutomoviles", automoviles);
        }

    }
}
