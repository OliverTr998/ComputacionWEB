using CapaDato.Models;
using CapaOperaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputacionWEB.Controllers
{
    public class HomeController : Controller
    {
        private ComputacionContext db;
        private FacultadService facultadService;
        public HomeController()
        {
            db = new ComputacionContext();
            facultadService = new FacultadService(db);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            var facultades = facultadService.GetAll().ToList();

            return View(facultades);
        }
    }
}