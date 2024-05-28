using CapaDato.Models;
using CapaDTO.DTO;
using CapaDTO.ViewModel;
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
            }).ToList();

            var indexFacultad = new IndexFacultadVM();
            indexFacultad.Facultades = facultades;

            ViewBag.JsonData = JsonConvert.SerializeObject(indexFacultad);

            return View();
        }

        [HttpGet]
        public JsonResult GetFacultades(string nombreFacultad)
        {
            var facultades = facultadService.GetAll().Select(x => new FacultadDTO
            {
                Id = x.Id,
                Codigo = x.Codigo,
                Descripcion = x.Descripcion,
            }).ToList();

            if (!string.IsNullOrEmpty(nombreFacultad))
            {
                facultades = facultades.Where(x => x.Descripcion.Trim().ToLower().Contains(nombreFacultad.Trim().ToLower())).ToList();
            }

            return Json(facultades, JsonRequestBehavior.AllowGet);
        }
    }
}