using AutoMapper;
using CapaDato.Models;
using CapaDTO.DTO;
using CapaOperaciones;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
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

        public VisualizadorReport()
        {
            db = new ComputacionContext();
            facultadService = new FacultadService(db);
            carreraService = new CarreraService(db);
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

                default: 
                    break;
            }

            ReportView.LocalReport.SetParameters(parameters);
        }
    }
}