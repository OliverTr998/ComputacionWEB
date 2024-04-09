using CapaDato.Models;
using CapaOperaciones;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputacionWEB.Controllers
{
    public class OperadoraTelefonoController : Controller
    {
        private ComputacionContext db;
        private OperadoraTelefonoService operadoraTelefonoService;

        public OperadoraTelefonoController()
        {
            db = new ComputacionContext();
            operadoraTelefonoService = new OperadoraTelefonoService(db);
        }

        public ActionResult Index()
        {
            var listaOperdoras = operadoraTelefonoService.GetAll();

            return View(listaOperdoras);
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(OperadoraTelefono operadoraTelefono)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(operadoraTelefono);
               
                var errorMessage = operadoraTelefonoService.ValidarAntesCrear(operadoraTelefono);
                if (string.IsNullOrEmpty(errorMessage))
                {
                    if (operadoraTelefonoService.Crear(operadoraTelefono))
                        return RedirectToAction("Index");

                    ViewBag.ErrorMessage = "Error De Servidor, Contacte Al Administrador";
                    return View(operadoraTelefono);
                }
                ViewBag.ErrorMessage = errorMessage;
                return View(operadoraTelefono);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error De Servidor, Contacte Al Administrador";
                return View(operadoraTelefono);
            }
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var operadoraTelefono = operadoraTelefonoService.BuscarId(id);

            if(operadoraTelefono == null)
                RedirectToAction("Index");

            return View(operadoraTelefono);
        }

        [HttpPost]
        public ActionResult Editar(OperadoraTelefono operadoraTelefono)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(operadoraTelefono);

                var errorMessage = operadoraTelefonoService.ValidarAntesActualizar(operadoraTelefono);
                if (string.IsNullOrEmpty(errorMessage))
                {
                    operadoraTelefonoService.Actualizar(operadoraTelefono);
                    return RedirectToAction("Index");
                }
                ViewBag.ErrorMessage = errorMessage;
                return View(operadoraTelefono);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error De Servidor, Contacte Al Administrador";
                return View(operadoraTelefono);
            }

        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            var operadoraTelefono = operadoraTelefonoService.BuscarId(id);

            if (operadoraTelefono == null)
                RedirectToAction("Index");

            return View(operadoraTelefono);
        }

        [HttpPost]
        public ActionResult Eliminar(OperadoraTelefono operadoraTelefono)
        {
            try
            {
                var errorMessage = operadoraTelefonoService.ValidarAntesEliminar(operadoraTelefono.Id);
                if (string.IsNullOrEmpty(errorMessage))
                {
                    if (operadoraTelefonoService.Eliminar(operadoraTelefono.Id))
                        return RedirectToAction("Index");

                    ViewBag.ErrorMessage = "Error De Servidor, Contacte Al Administrador";
                    return View(operadoraTelefono);
                }
                ViewBag.ErrorMessage = errorMessage;
                return View(operadoraTelefono);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error De Servidor, Contacte Al Administrador";
                return View(operadoraTelefono);
            }

        }
    }
}