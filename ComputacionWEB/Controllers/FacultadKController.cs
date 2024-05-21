using CapaDato.Models;
using CapaDTO;
using CapaOperaciones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputacionWEB.Controllers
{
    public class FacultadKController : Controller
    {
        private ComputacionContext db;
        private FacultadService facultadService;

        public FacultadKController()
        {
            db = new ComputacionContext();
            facultadService = new FacultadService(db);
        }

        public ActionResult Index()
        {
            var facultades = facultadService.GetAll().Select(x=> new FacultadDTO
            {
                Id = x.Id,
                Codigo = x.Codigo,
                Descripcion = x.Descripcion,
            });

            ViewBag.JsonData = JsonConvert.SerializeObject(new { Facultades = facultades });

            return View();
        }

        [HttpGet]
        public JsonResult GetFacultades()
        {
            return Json("Hola Mundo", JsonRequestBehavior.AllowGet);
        }
    }
}