using CapaDato.Models;
using CapaDTO.DTO;
using CapaDTO.Utilities;
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
    public class EstudianteController : Controller
    {
        private ComputacionContext db;
        private EstudianteService estudianteService;
        private CarreraService carreraService;
        private OperadoraTelefonoService operadoraTelefonoService;

        public EstudianteController()
        {
            db = new ComputacionContext();
            estudianteService = new EstudianteService(db);
            carreraService = new CarreraService(db);
            operadoraTelefonoService = new OperadoraTelefonoService(db);
        }

        // GET: Estudiante
        public ActionResult Index()
        {
            var estudiantes = estudianteService.GetEstudiantes();

            var carreras = carreraService.GetAll().Select(x => new CarreraDTO
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
            }).ToList();

            var operadoraTelefonos = operadoraTelefonoService.GetAll().Select(x => new OperadoraTelefonoDTO
            {
                Id = x.Id,
                Descripcion = x.Descripcion
            }).ToList();
            
            var indexEstudiante = new IndexEstudianteVM();
            indexEstudiante.Estudiantes = estudiantes;
            indexEstudiante.Carreras = carreras;
            indexEstudiante.OperadoraTelefonos = operadoraTelefonos;

            ViewBag.ListaCarrera = new SelectList(carreras, "Id", "Descripcion");
            ViewBag.ListaOperadora = new SelectList(operadoraTelefonos, "Id", "Descripcion");

            ViewBag.JsonData = JsonConvert.SerializeObject(indexEstudiante);

            return View(indexEstudiante);
        }

        [HttpGet]
        public JsonResult GetEstudiantes()
        {
            try
            {
                var estudiantes = estudianteService.GetEstudiantes();

                return Json(new RequestResult(estudiantes), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new RequestResult(SystemMessage.ServerError, success: false), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetEstudiantesFilter(FiltrosEstudianteVM viewModel)
        {
            try
            {
                var estudiantes = estudianteService.GetEstudiantesFilter(viewModel);

                return Json(new RequestResult(estudiantes), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new RequestResult(SystemMessage.ServerError, success: false), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Crear(Estudiante estudiante)
        {
            try
            {
                var errorMensaje = !ModelState.IsValid ? SystemMessage.ValidatePropertyError : estudianteService.ValidarAntesCrear(estudiante);

                if (string.IsNullOrEmpty(errorMensaje))
                {
                    if (estudianteService.Crear(estudiante))
                        return Json(new RequestResult(SystemMessage.CreateSuccessful));

                    else
                        return Json(new RequestResult(SystemMessage.ServerError, success: false));
                }
                else
                    return Json(new RequestResult(errorMensaje, success: false));
            }
            catch (Exception ex)
            {
                return Json(new RequestResult(SystemMessage.ServerError, success: false), JsonRequestBehavior.AllowGet);
            }
        }
    }
}