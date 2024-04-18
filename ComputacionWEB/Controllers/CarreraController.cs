using CapaDato.Models;
using CapaOperaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputacionWEB.Controllers
{
    public class CarreraController : Controller
    {
        private ComputacionContext db;
        private CarreraService carreraService;
        private FacultadService facultadService;

        public CarreraController()
        {
            db = new ComputacionContext();
            carreraService = new CarreraService(db);
            facultadService = new FacultadService(db);
        }
    
        // GET: Carrera
        public ActionResult Index()
        {

            var listaCarreras = carreraService.GetAll();
            return View(listaCarreras);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            var facultades = facultadService.GetAll();

            ViewBag.ListaFacultad = new SelectList(facultades, "Id", "Descripcion");

            return View();
        }

        [HttpPost]
        public ActionResult Crear(Carrera carrera)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(carrera);
                }

                var errorMensaje = carreraService.ValidarAntesCrear(carrera);
                if (string.IsNullOrEmpty(errorMensaje))
                {
                    if (carreraService.Crear(carrera))
                        return RedirectToAction("Index");

                    ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador";
                    return View(carrera);
                }

                ViewBag.ErrorMensaje = errorMensaje;
                return View(carrera);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador";
                return View(carrera);
            }
        }

        //[HttpGet]
        //public ActionResult Editar(int id)
        //{
        //    var facultad = facultadService.BuscarId(id);

        //    if (facultad == null)
        //        return RedirectToAction("Index");

        //    return View(facultad);
        //}

        //[HttpPost]
        //public ActionResult Editar(Facultad facultad)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return View(facultad);
        //        }

        //        var errorMensaje = facultadService.ValidarAntesActualizar(facultad);
        //        if (string.IsNullOrEmpty(errorMensaje))
        //        {
        //            facultadService.Actualizar(facultad);
        //            return RedirectToAction("Index");
        //        }

        //        ViewBag.ErrorMensaje = errorMensaje;
        //        return View(facultad);
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador";
        //        return View(facultad);
        //    }
        //}

        //[HttpGet]
        //public ActionResult Eliminar(int id)
        //{
        //    var facultad = facultadService.BuscarId(id);

        //    if (facultad == null)
        //        return RedirectToAction("Index");

        //    return View(facultad);
        //}

        //[HttpPost]
        //public ActionResult Eliminar(Facultad facultad)
        //{
        //    try
        //    {
        //        var errorMensaje = facultadService.ValidarAntesEliminar(facultad.Id);
        //        if (string.IsNullOrEmpty(errorMensaje))
        //        {
        //            if (facultadService.Eliminar(facultad.Id))
        //                return RedirectToAction("Index");

        //            ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador";
        //            return View(facultad);
        //        }

        //        ViewBag.ErrorMensaje = errorMensaje;
        //        return View(facultad);
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador";
        //        return View(facultad);
        //    }
        //}
    }
}