using AutoMapper;
using CapaDato.Models;
using CapaDTO.DTO;
using CapaOperaciones;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComputacionWEB.ViewReport
{
    
    public partial class VisualizadorReport : System.Web.UI.Page
    {
        private ComputacionContext db;
        private FacultadService facultadService;
        private CarreraService carreraService;
        private EstudianteService estudianteService;

        public VisualizadorReport()
        {
            db = new ComputacionContext();
            facultadService = new FacultadService(db);
            carreraService = new CarreraService(db);
            estudianteService = new EstudianteService(db);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack) return;

            CargaReporte();
        }

        private void CargaReporte()
        {  // Reporte = "RptFacultades.rdlc"
            string urlReport = "~/Informes/" + Request.QueryString["Reporte"];
            ReportView.ProcessingMode = ProcessingMode.Local;
            ReportView.LocalReport.DataSources.Clear();
            ReportView.LocalReport.ReportPath = Server.MapPath(urlReport);

            List<ReportParameter> parameters = new List<ReportParameter>();
            switch (Request.QueryString["Reporte"])
            {
                case "RptFacultades.rdlc":
                    {
                        var facultades = facultadService.GetAll();
                        var conjuntoDatos = new ReportDataSource("Data", facultades);
                        ReportView.LocalReport.DataSources.Add(conjuntoDatos);
                        //parameters.Add(new ReportParameter("", DateTime.Now.ToString()));
                    }
                    break;

                case "RptCarrera.rdlc":
                    {
                        var carreras = Mapper.Map<ICollection<CarreraDTO>>(carreraService.GetAll().ToList());
                        var conjuntoDatos = new ReportDataSource("Data", carreras);
                        ReportView.LocalReport.DataSources.Add(conjuntoDatos);
                    }
                    break;

                case "RptGrEstudiantesXCarrera.rdlc":
                    {
                        var estudiante = estudianteService.RptGrEstudiantesXCarrera();
                        var conjuntoDatos = new ReportDataSource("Data", estudiante);
                        ReportView.LocalReport.DataSources.Add(conjuntoDatos);
                    }
                    break;

                case "RptEstudiantes.rdlc":
                    {
                        var estudiantes = Mapper.Map <ICollection<EstudianteDTO>>(estudianteService.GetAll());
                        var conjuntoDatos = new ReportDataSource("Data", estudiantes);
                        ReportView.LocalReport.DataSources.Add(conjuntoDatos);
                    }
                    break;

                case "RptTotalTelefonoXFacultad.rdlc":
                    {
                        var facultad = facultadService.RptTotalTelefonoXFacultad();
                        var conjuntoDatos = new ReportDataSource("Data", facultad);
                        ReportView.LocalReport.DataSources.Add(conjuntoDatos);
                    }
                    break;

                case "RptEstudianteFacultad.rdlc":
                    {
                        var facultadId = int.Parse(Request.Params["FacultadId"]);
                        var estudiantesXFacultad = facultadService.RptEstudianteFacultad(facultadId);
                        var conjuntoDatos = new ReportDataSource("Data", estudiantesXFacultad);
                        ReportView.LocalReport.DataSources.Add(conjuntoDatos);
                    }
                    break;
                default: 
                    break;
            }

            ReportView.LocalReport.SetParameters(parameters);
        }
    }
}