using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaNegocio;
using Microsoft.Reporting.WebForms;

namespace PulperiaChina.Reportes
{
    public partial class UltimosIngresados : System.Web.UI.Page
    {
        private ClassReporte reporte = new ClassReporte();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    txtinicio.Text = DateTime.Today.ToString();
                    txtfinal.Text = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59).ToString();
                    ReportDataSource rdt = new ReportDataSource();
                    rdt.Value= reporte.IngresadosXFecha(Convert.ToDateTime(txtinicio.Text.Trim()), Convert.ToDateTime(txtfinal.Text.Trim()));
                    rdt.Name = "DataSet1";
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(rdt);
                    ReportViewer1.LocalReport.ReportEmbeddedResource = "PulperiaChina.Reportes.UltimosIngresos.rdlc";
                    ReportViewer1.LocalReport.ReportPath = "Reportes/UltimosIngresos.rdlc";
                    ReportViewer1.LocalReport.Refresh();
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }

        protected void btnver_Click(object sender, EventArgs e)
        {
            ReportDataSource rdt = new ReportDataSource();

            rdt.Value = reporte.IngresadosXFecha(Convert.ToDateTime(txtinicio.Text.Trim()), Convert.ToDateTime(txtfinal.Text.Trim()));
            rdt.Name = "DataSet1";
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rdt);
            ReportViewer1.LocalReport.ReportEmbeddedResource = "PulperiaChina.Reportes.UltimosIngresos.rdlc";
            ReportViewer1.LocalReport.ReportPath = "Reportes/UltimosIngresos.rdlc";
            ReportViewer1.LocalReport.Refresh();
            //Response.Redirect("/Visitantes/Inicio.aspx");
        }
    }
}