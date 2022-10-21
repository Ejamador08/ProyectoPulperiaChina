using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Web.Security;

using CapaNegocio;
using CapaEntidad;


namespace PulperiaChina.Visitantes
{
    public partial class MaestraVisitante : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.IsAuthenticated)
                {
                    string user = HttpContext.Current.User.Identity.Name;
                    var usuario = new ClassNegUsuario();

                    var info = usuario.BuscaUsuario(user);

                    Literal lit = (Literal)LoginView1.FindControl("LiteralUser");
                    Image img = (Image)LoginView1.FindControl("ImgUser");

                    lit.Text = string.Format("{0} {1}", info.Nombre_User, info.Apellido1_User);


                    //revisarxq no me muestra la imagen
                    //img.ImageUrl = info.ImgUser;
                }
                //si esta registrado
                //if (Request.IsAuthenticated)
                //{
                //    string user = HttpContext.Current.User.Identity.Name;
                //    var use = new ClassNegUsuario();

                //    var info = use.BuscaUsuario(user);

                //    //permite encontrar un control dentro de otro control
                //    Literal lit = (Literal)LoginView1.FindControl("LiteralUser");

                //    //concatenacion valida pero no es buena pues tarda en ejecutar...
                //    //lit.Text = info.Nombres + " " + info.Apellido1;

                //    //esta es la mejor manera de concatenar
                //    lit.Text = string.Format("{0} {1}", info.Nombre, info.Apellido);
                //}
            }

        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            e.Cancel = true;

            Response.Redirect("/Cuenta/Login.aspx");
        }
    }
}