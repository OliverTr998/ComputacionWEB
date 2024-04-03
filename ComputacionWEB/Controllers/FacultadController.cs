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
    }
}