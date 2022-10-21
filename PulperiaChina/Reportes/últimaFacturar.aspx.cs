using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using CapaNegocio;
using Microsoft.Reporting.WebForms;//libreria para el reporte


namespace PulperiaChina.Reportes
{
    public partial class últimaFacturar : System.Web.UI.Page
    {
        public ClassReporte reporte = new ClassReporte();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ReportDataSource rdt = new ReportDataSource();
                    rdt.Value = reporte.ultimafactura(ClassNegFacturacion.ultimoID());
                    rdt.Name = "DataSet1";

                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(rdt);
                    ReportViewer1.LocalReport.ReportEmbeddedResource = "PulperiaChina.Reportes.últimaFactura.rdlc";
                    ReportViewer1.LocalReport.ReportPath = "Reportes/últimaFactura.rdlc";
                    ReportViewer1.LocalReport.Refresh();
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }

        }

        protected void btnnuevafactura_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Ventas/FormVentas.aspx");
        }
    }
}