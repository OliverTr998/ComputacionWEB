<%@ Page Language="C#" Debug="true" AutoEventWireup="true" CodeBehind="VisualizadorReport.aspx.cs" Inherits="ComputacionWEB.ViewReport.VisualizadorReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="~/Content/Externos/Bootstrsap/bootstrap.min.css" rel="stylesheet" />
    <title>Visor De Reporte</title>
</head>
<body>

    <!--Encabezado del Visualizador-->
    <div class="row text-center">
        <div class="col-12">
            <h3 class="fw-bold">VISOR DE INFORMES</h3>
        </div>
    </div>

    <!--Boton Cerrar Ventana-->
    <div class="row mb-2 justify-content-center">
        <div class="col-2 d-grid">
            <button type="button" class="btn btn-danger" onclick="window.close()">
                Cerrar
            </button>
        </div>
    </div>

    <!--Visualizador De Reporte-->
    <form id="form1" runat="server" method="post" target="IframeReporte" style="width: -moz-max-content; width: -webkit-max-content; margin: 0 auto;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportView"  runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="900px"  ShowWaitControlCancelLink="False" SizeToReportContent="True"></rsweb:ReportViewer>
    </form>

</body>
</html>
