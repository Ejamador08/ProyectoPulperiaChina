using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaEntidad;
using CapaNegocio;

namespace PulperiaChina.Visitantes
{
    public partial class Inicio : System.Web.UI.Page
    {
        #region Muestra x Cantidad
        public void MostrarUltimosArticulos()
        {
            var art = new ClassNegArticulo();
            LisArticulos.DataSource = art.MuestraxCantidad(8);
            LisArticulos.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarUltimosArticulos();
            }
        }

        protected void DropCategoriaAjax_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //enlace a la pagina registro a partir del boton Registro en inicio
        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cuenta/Registro.aspx");
        }

        //enlace a la pagina login a partir del boton login en inicio
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cuenta/Login.aspx");
        }
    }
}