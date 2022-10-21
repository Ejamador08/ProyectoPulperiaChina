using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PulperiaChina.Cuenta
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAccesar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Membership.ValidateUser(txtUsuario.Text, txtPasword.Text))
                {
                    ///Si estamos aca es que es usuario es valido
                    ///
                    //Declaramos un arreglo llamado Rol
                    //y le asignamos los roles de usuario
                    string[] Rol = Roles.GetRolesForUser(txtUsuario.Text);
                    //Redireccionamos a la pagina solicitada por el usuario
                    FormsAuthentication.RedirectFromLoginPage(txtUsuario.Text, true);

                    for (int i = 0; i < Rol.Length; i++)
                    {
                        if (Rol[i] == "Administrador")
                        {
                            Response.Redirect("~/ConfigAdmin.aspx");
                        }
                        if (Rol[i] == "Vendedor")
                        {
                            Response.Redirect("~/EntradaVend.aspx");
                        }
                    }
                }
                else
                {
                    LiteralMensaje.Text = "EL usuario o la contraseña es invalido, intentelo nuevamente";
                }
            }
            catch (Exception)
            {
                LiteralMensaje.Text = "La conexión ha tardado demasiado, intentelo nuevamente.";
            }
        }
    }
}