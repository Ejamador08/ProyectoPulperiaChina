using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaEntidad;
using CapaNegocio;
using System.IO;

namespace PulperiaChina.Visitantes
{
    public partial class Usuario : System.Web.UI.Page
    {
        #region Metodos
        #region Limpiar Controles
        public void LimpiarControles()
        {
            txtnombre.Text = "";
            txtApellido.Text = "";
            txtuser.Text = "";
            Droptipouser.Text = "Seleccione...";
        }
        #endregion

        #region Guardar Usuario
        public bool GuardaUsuario()
        {
            ClassEntUsuario ent = new ClassEntUsuario();
            ent.Nombre_User = txtnombre.Text;
            ent.Apellido1_User = txtApellido.Text;
            ent.Apellido2_User = txtapellido02.Text;
            ent.UserName = txtuser.Text;
            ent.Tipo_Usuario = Droptipouser.Text;
            SubirImagen();
            ent.ImgUser = HiddenField1.Value;


            ClassNegUsuario neg = new ClassNegUsuario();

            if (neg.Buscarusuariosduplicados(ent).Count < 1)
                {
                  bool resp = neg.GuardaUsuario(ent);
                  return resp;
                } 
            else
                {
                    LiteralMensaje.Text = "El Usuario" + ent.Nombre_User + "Ya Existe";
                    return false;
                }
        }
        #endregion

        #region Actualizar Usuario
        public bool ActulizaUsuario()
        {
            ClassEntUsuario ent = new ClassEntUsuario();
            ent.ID_Usuario = Convert.ToInt32(txtcodigo.Text);
            ent.Nombre_User = txtnombre.Text;
            ent.Apellido1_User = txtApellido.Text;
            ent.Apellido2_User = txtapellido02.Text;
            ent.UserName = txtuser.Text;
            ent.Tipo_Usuario = Droptipouser.Text;
            SubirImagen();
            ent.ImgUser = HiddenField1.Value;

            ClassNegUsuario neg = new ClassNegUsuario();
            bool resp = neg.ActualizaUsuario(ent);
            return resp;
         }
        #endregion

        #region Buscar Usuario
        public void BuscaUsuario(string name)
        {
            var neg = new ClassNegUsuario();
            GridViewUsuario.DataSource = neg.BuscaUsuarioxNombre(name);
            GridViewUsuario.DataBind();
        }
        #endregion

        #region Llenar Grid Usuario
        public void LlenaGrid()
        {
            var neg = new ClassNegUsuario();
            GridViewUsuario.DataSource = neg.MuestraUsuario();
            GridViewUsuario.DataBind();
        }
        #endregion

        #region  Subir Imagen Usuario
        public string SubirImagen()
        {

            bool fileOk = false;
            string respuesta = "";
            string ruta = Server.MapPath("/Imagenes/ImagenesUsuarios/");
            try
            {
                if (FileUploadUsuario.HasFile)//Si tiene archivo seleccionado
                {
                    string extension = Path.GetExtension(FileUploadUsuario.FileName).ToLower();
                    string[] extensionValida = { ".jpg", ".png", ".gif", ".jpeg" };
                    for (int i = 0; i < extensionValida.Length; i++)
                    {

                        if (extension == extensionValida[i])
                        {
                            fileOk = true;
                        }

                        if (fileOk)
                        {
                            string nombreImg = FileUploadUsuario.FileName.ToString();
                            FileUploadUsuario.PostedFile.SaveAs(ruta + nombreImg);
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
        //************************************************//

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiViewUsuario.ActiveViewIndex = 0;
                LlenaGrid();
            }
        }

        //************************************************//
        #region Botones
        protected void btnLista_Click(object sender, EventArgs e)
        {
            MultiViewUsuario.ActiveViewIndex = 0;
            LlenaGrid();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            //MultiViewUsuario.ActiveViewIndex = 1;
            if (ActulizaUsuario())
            {
                LiteralMensaje.Text = "<div class='alert alert-success' role='alert'>Usuario Actualizado con Exito</div>";
                SubirImagen();
            }
            else
            {
                LiteralMensaje.Text = "<div class='alert alert-danger' role='alert'>Error al Actualizar Usuario</div>";
            }
            LimpiarControles();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //GuardaUsuario();
            //LimpiarControles();
            MultiViewUsuario.ActiveViewIndex = 1;
            if (GuardaUsuario())
           {
                LiteralMensaje.Text="<div class='alert alert-success' role='alert'>Usuario Guardado con Exito</div>";
                SubirImagen();
            }
            else
            {
                LiteralMensaje.Text = "<div class='alert alert-danger' role='alert'>Ya Existe un Usuario con eso Datos</div>";
            }
            LimpiarControles();
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            BuscaUsuario(txtbuscar.Text);
        }
        #endregion

        //************************************************//
        #region comandos Botones dela Grilla
        protected void GridViewUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int indice = row.RowIndex;
            int codigo = Convert.ToInt32(GridViewUsuario.DataKeys[indice].Value);

            var neg = new ClassNegUsuario();
            var ent = new ClassEntUsuario();

            if (e.CommandName=="cmdeditar")
            {
                ent = neg.BuscaxID(codigo);
                txtcodigo.Text = ent.ID_Usuario.ToString();
                txtnombre.Text = ent.Nombre_User;
                txtApellido.Text = ent.Apellido1_User;
                txtapellido02.Text = ent.Apellido2_User;
                txtuser.Text = ent.UserName;
                Droptipouser.SelectedValue = ent.Tipo_Usuario;
                HiddenField1.Value = ent.ImgUser;

                Imageuser.ImageUrl = HiddenField1.Value;

                MultiViewUsuario.ActiveViewIndex = 1;

                btnGuardar.Visible = false;
                btnGuardar.Enabled = false;

                btnActualizar.Visible = true;
                btnActualizar.Enabled = true;

                btncancelar.Visible = true;
            }
            if (e.CommandName=="cmdeliminar")
            {
                bool resp = neg.EliminaUsuario(codigo);
                if (resp)
                {
                    LiteralEliminar.Text="<div class='alert alert-success' role='alert'>El Usuario se ha Eliminado</div>";
                    LlenaGrid();
                }
                else
                {
                    LiteralEliminar.Text = "<div class='alert alert-warning' role='alert'>ha pasado un problema, no se Eliminò</div>";
                }
            }
        }
        #endregion  

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            MultiViewUsuario.ActiveViewIndex = 0;
            txtbuscar.Text = "";
        }

        protected void dropuserpage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewUsuario.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("dropuserpage");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...           
                GridViewUsuario.PageIndex = pageList.SelectedIndex;
                //------------------------------
                LlenaGrid();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        protected void GridViewUsuario_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewUsuario.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("dropuserpage");
                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("lblborart");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GridViewUsuario.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GridViewUsuario.PageIndex)
                        {
                            item.Selected = true;
                        }
                        // Se añade el ListItem a la colección de Items del DropDownList...
                        pageList.Items.Add(item);
                    }
                }
                if ((pageLabel != null))
                {
                    // Calcula el nº de �gina actual...
                    int currentPage = GridViewUsuario.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GridViewUsuario.PageCount.ToString();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}