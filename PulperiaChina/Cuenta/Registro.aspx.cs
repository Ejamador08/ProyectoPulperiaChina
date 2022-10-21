using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaEntidad;
using CapaNegocio;
using System.IO;

namespace PulperiaChina.Cuenta
{
    public partial class Registro : System.Web.UI.Page
    {
        #region Metodos
        #region Limpia Controles
        public void LimpiaControles()
        {
            txtNombreUsuario.Text = "";
            txtPassword.Text = "";
            txtPasswordCOnfirm.Text = "";
            txtEmail.Text = "";
            txtRespuesta.Text = "";
            DropTipoUsuario.SelectedValue = "--Seleccione el Tipo de Usuario--";
            DropPreguntas.SelectedValue = "--Seleccione una Pregunta de Seguridad--";


            txtNombres.Text = "";
            txtApellido.Text = "";
            txtusername.Text = "";
        }
        #endregion

        #region Creacion de usuario en ASP.NET y lo guarda en la DB
        public void GuardaUsuarioDB()
        {
            var user = new ClassEntUsuario();
            
            user.Nombre_User = txtNombreUsuario.Text;
            user.Apellido1_User = txtApellido.Text;
            user.Apellido2_User = txtPassword.Text;
            user.UserName = txtusername.Text;
            user.Tipo_Usuario = DropTipoUsuario.SelectedValue;
            SubirImgagen();
            user.ImgUser = HiddenField1.Value;

            var neg = new ClassNegUsuario();
            neg.GuardaUsuario(user);
        }
        #endregion

        #region Guarda Usuario en ASP.Net
        public string GuardarUsuario()
        {
            string resp = "";
            MembershipCreateStatus createStatus;
            try
            {

                MembershipUser user = Membership.CreateUser(txtNombreUsuario.Text,
                                                            txtPassword.Text, txtEmail.Text,
                                                            DropPreguntas.SelectedItem.Text,
                                                            txtRespuesta.Text,
                                                            true,
                                                            out createStatus);


                switch (createStatus)
                {
                    case MembershipCreateStatus.Success:
                        resp = "Correcto";
                        Roles.AddUserToRole(txtNombreUsuario.Text, DropTipoUsuario.SelectedValue);//Agrega el Rol de Estudiante al usuario
                        //GuardaUsuarioDB();
                        break;
                    // This Case Occured whenver we send duplicate UserName
                    case MembershipCreateStatus.DuplicateUserName:

                        resp = "Un usuario con el mismo nombre ya existe!";
                        break;
                    //This Case Occured whenver we give duplicate mail id
                    case MembershipCreateStatus.DuplicateEmail:

                        resp = "Un usuario con la misma dirección de correo electrónico ya existe!";
                        break;
                    //This Case Occured whenver we send invalid mail format
                    case MembershipCreateStatus.InvalidEmail:

                        resp = "La dirección de correo electrónico que proporcionó no es válido.";
                        break;


                    //This Case Occured whenver we send empty data or Invalid Data
                    case MembershipCreateStatus.InvalidAnswer:

                        resp = "La respuesta de seguridad no es válida.";
                        break;
                    // This Case Occured whenver we supplied weak password
                    case MembershipCreateStatus.InvalidPassword:

                        resp = "La contraseña que ha proporcionado no es válido. Debe ser 7 caracteres de longitud y tener al menos 1 carácter especial";
                        break;
                    default:

                        resp = "Se ha producido un error desconocido: La cuenta de usuario no se ha creado.";
                        break;
                }
                return resp;
            }
            catch (Exception)
            {

                return "Error";
            }
        }
        #endregion

        #region Crea Usuario en ASP.NET aun no utilizada
        void CrearUsuarioAsp(string rol, ClassEntUsuario user)
        {
            MembershipCreateStatus createstatus;
            MembershipUser newuser = Membership.CreateUser(txtNombreUsuario.Text, txtPassword.Text, txtEmail.Text,
                                                            DropPreguntas.SelectedItem.Text,
                                                            txtRespuesta.Text,
                                                            true,
                                                            out createstatus);
            switch (createstatus)
            {
                case MembershipCreateStatus.Success:
                    Roles.AddUserToRole(txtNombreUsuario.Text, rol);
                    break;

                case MembershipCreateStatus.DuplicateEmail:
                    break;
                case MembershipCreateStatus.DuplicateProviderUserKey:
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    break;
                case MembershipCreateStatus.InvalidProviderUserKey:
                    break;
                case MembershipCreateStatus.InvalidQuestion:
                    break;
                case MembershipCreateStatus.InvalidUserName:
                    break;
                case MembershipCreateStatus.ProviderError:
                    break;
                case MembershipCreateStatus.UserRejected:
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Subir Imagen usuario
        public string SubirImgagen()
        {
            bool fileOk = false;
            string respuesta = "";
            string ruta = Server.MapPath("~/Imagenes/ImagenesUsuarios/");

            try
            {
                if (FileUpload1.HasFile)//Si tiene archivo seleccionado
                {
                    string extension = Path.GetExtension(FileUpload1.FileName).ToLower();
                    string[] extensionValida = { ".jpg", ".png", ".gif", ".jpeg" };
                    for (int i = 0; i < extensionValida.Length; i++)
                    {

                        if (extension == extensionValida[i])
                        {
                            fileOk = true;
                        }

                        if (fileOk)
                        {
                            string nombreImg = FileUpload1.FileName.ToString();
                            FileUpload1.PostedFile.SaveAs(ruta + nombreImg);
                            HiddenField1.Value = "/Imagenes/ImagenesUsuarios/" + nombreImg;
                            respuesta = "subida";
                        }
                        else
                        {
                            HiddenField1.Value = "/Imagenes/Usuarios.png";
                            respuesta = "Error";
                        }
                    }
                }
                else
                {
                    HiddenField1.Value = "/Imagenes/Usuarios.png";
                    respuesta = "Error";
                }
                return respuesta;
            }
            catch (Exception)
            {

                return respuesta;
            }
        }
        #endregion
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        #region Boton Registrar
        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            GuardarUsuario();
            GuardaUsuarioDB();
            LiteralMensaje.Text = LiteralMensaje.Text = "<div class='alert alert-success' role='alert'>Nuevo Usuario Creado Con Exito...</div>";
            LimpiaControles();
        }
        #endregion
    }
}