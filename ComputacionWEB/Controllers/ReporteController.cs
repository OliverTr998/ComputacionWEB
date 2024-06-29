using CapaDato.Models;
using CapaDTO.ViewModel;
using CapaOperaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputacionWEB.Controllers
{
    public class ReporteController : Controller
    {
        private ComputacionContext db;
        private FacultadService facultadService;

        public ReporteController()
        {
            db = new ComputacionContext();
            facultadService = new FacultadService(db);
        }
        // GET: Reporte
        public ActionResult RptEstudianteFacultad()
        {
            var facultades = facultadService.GetAll();

            ViewBag.Facultades = new SelectList(facultades, "Id", "Descripcion");

            return View(new RptEstudianteFacultadVM());
        }
    }
}