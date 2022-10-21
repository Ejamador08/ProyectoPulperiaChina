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
    public partial class MasVendido : System.Web.UI.Page
    {
        private ClassReporte report = new ClassReporte();
             


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ReportDataSource rdt = new ReportDataSource();
                    rdt.Value = report.Mas_Vendidos();
                    rdt.Name = "DataSet1";
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(rdt);
                    ReportViewer1.LocalReport.ReportEmbeddedResource="PulperiaChina.Reportes.MasVendidos.rdlc";
                    ReportViewer1.LocalReport.ReportPath="Reportes/MasVendidos.rdlc";
                    ReportViewer1.LocalReport.Refresh();
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }
    }
}