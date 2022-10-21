using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PulperiaChina.Reportes
{
    public partial class Reporte1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnmasvendidos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reportes/MasVendido.aspx");
        }
    }
}