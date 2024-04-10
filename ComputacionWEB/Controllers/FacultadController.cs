using CapaDato.Models;
using CapaOperaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputacionWEB.Controllers
{
    public class FacultadController : Controller
    {
        private ComputacionContext db;
        private FacultadService facultadService;

        public FacultadController()
        {
            db = new ComputacionContext();
            facultadService = new FacultadService(db);
        }
        // GET: Facultad
        public ActionResult Index()
        {
            var listaFacultades = facultadService.GetAll();

            return View(listaFacultades);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Facultad facultad)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(facultad);
                }

                var errorMensaje = facultadService.ValidarAntesCrear(facultad);
                if (string.IsNullOrEmpty(errorMensaje))
                {
                    if (facultadService.Crear(facultad))
                        return RedirectToAction("Index");

                    ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador";
                    return View(facultad);
                }

                ViewBag.ErrorMensaje = errorMensaje;
                return View(facultad);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador";
                return View(facultad);
            }
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var facultad = facultadService.BuscarId(id);

            if(facultad == null) 
                return RedirectToAction("Index");

            return View(facultad);
        }

        [HttpPost]
        public ActionResult Editar(Facultad facultad)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(facultad);
                }

                var errorMensaje = facultadService.ValidarAntesActualizar(facultad);
                if (string.IsNullOrEmpty(errorMensaje))
                {
                    facultadService.Actualizar(facultad);
                    return RedirectToAction("Index");
                }

                ViewBag.ErrorMensaje = errorMensaje;
                return View(facultad);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMensaje = "Error servidor, Contactar al alministrador";
                return View(facultad);
            }
        }
    }
}