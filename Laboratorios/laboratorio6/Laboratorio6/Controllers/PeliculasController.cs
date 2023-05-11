using Microsoft.AspNetCore.Mvc;
using Laboratorio6.Handlers;
using Laboratorio6.Models;
using System.Data.SqlClient;

namespace Laboratorio6.Controllers
{
    public class PeliculasController : Controller
    {
        public IActionResult Index()
        {
            PeliculasHandler peliculasHandler = new PeliculasHandler();
            var peliculas = peliculasHandler.ObtenerPeliculas();
            ViewBag.MainTitle = "Lista de Peliculas";
            return View(peliculas);
        }

        [HttpGet]
        public ActionResult CrearPelicula() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearPelicula(PeliculaModelo pelicula)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    PeliculasHandler peliculasHandler = new PeliculasHandler();
                    ViewBag.ExitoAlCrear = peliculasHandler.CrearPelicula(pelicula);

                    if (ViewBag.ExitoAlCrear)
                    {
                        ViewBag.Message = "La película " + pelicula.Nombre + " fue creada con éxito.";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salió mal y no fue posible crear la película ";
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditarPelicula(int? identificador)
        {
            ActionResult vista;
            try
            {
                var peliculahandler = new PeliculasHandler();
                var pelicula = peliculahandler.ObtenerPeliculas().Find(model => model.ID == identificador);
                if (pelicula == null)
                {
                    vista = RedirectToAction("Index");
                }
                else {
                    vista = View(pelicula);
                }
            }
            catch
            {
                vista = RedirectToAction("Index");
            }

            return vista;
        }

        [HttpPost]
        public ActionResult EditarPelicula(PeliculaModelo pelicula)
        {
            try
            {
                var peliculahandler = new PeliculasHandler();
                peliculahandler.EditarPelicula(pelicula);
                return RedirectToAction("Index", "Peliculas");
                
            }
            catch
            {
                ViewBag.Mensaje = "La modificacion de la pelicula tuvo un error";
                return View();
            }
        }


        [HttpGet]
        public ActionResult BorrarPelicula(int? identificador)
        {
            ActionResult vista;
            try

            {
             
                var peliculahandler = new PeliculasHandler();
                var pelicula = peliculahandler.ObtenerPeliculas().Find(model => model.ID == identificador);
                if (pelicula == null)
                {
                    vista = RedirectToAction("Index");
                }
                else
                {
                    peliculahandler.BorrarPelicula(pelicula);
                    vista = RedirectToAction("Index");
                }
            }
            catch
            {
                vista = RedirectToAction("Index");
            }

            return vista;
        }



    }
}
