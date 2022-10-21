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
    public partial class Empleado : System.Web.UI.Page
    {
        #region Metodos
        #region Limpia Controles
        public void LimpiarControles()
        {
            txtnombre.Text = "";
            txtapepat.Text = "";
            txtapemat.Text = "";
            txtdirexion.Text = "";
            txttelefono.Text = "";
            txtmail.Text = "";
            txtuser.Text = "";
        }
        #endregion
        #region Llena Grid
        public void LlenaGrid()
        {
            var neg = new ClassNegEmpleado();
            GridViewEmpleado.DataSource = neg.MuestraEmpleado();
            GridViewEmpleado.DataBind();
        }
        #endregion
        public void LlenarGridInactivos()
        {
            var neg = new ClassNegEmpleado();
            GVInactivos.DataSource = neg.MuestraEmpleadoInactivos();
            GVInactivos.DataBind();
        }
        #region Llena Grid x Nombre
        public void LlenaGridxNombre(string name)
        {
            var neg = new ClassNegEmpleado();
            GridViewEmpleado.DataSource = neg.MuestaEmpleadoxNombre(name);
            GridViewEmpleado.DataBind();
        }
        #endregion
        public void LleneGridXNombreInactivos(string name)
        {
            var neg = new ClassNegEmpleado();
            GVInactivos.DataSource = neg.MuestaEmpleadoxNombreInactivos(name);
            GVInactivos.DataBind();
        }
        #region Guardar Empleado
        public bool GuardaEmpleado()
        {
            var ent = new ClassEntEmpleado();
            ent.Nombre = txtnombre.Text;
            ent.Apellido1 = txtapepat.Text;
            ent.Apellido2 = txtapemat.Text;
            ent.Direccion = txtdirexion.Text;
            ent.Telefono = txttelefono.Text;
            ent.E_Mail = txtmail.Text;
            ent.UserName = txtuser.Text;
            ent.Estado = CheckEstado.Checked;
            RutaImagen();
            ent.ImgEmpleado = HiddenField1.Value;

            var neg = new ClassNegEmpleado();
            if (neg.BuscaEmpleadoDuplicado(ent).Count < 1)
            {
                bool resp = neg.GuardaEmpleado(ent);
                return resp;
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo guardar', 'error');", true);
                return false;
            }
        }
        #endregion
        #region Actualiza Empleado
        public bool ActualizaEmpleado()
        {
            var ent = new ClassEntEmpleado();
            ent.IDEmpleado = Convert.ToInt32(txtcodigo.Text);
            ent.Nombre = txtnombre.Text;
            ent.Apellido1 = txtapepat.Text;
            ent.Apellido2 = txtapemat.Text;
            ent.Direccion = txtdirexion.Text;
            ent.Telefono = txttelefono.Text;
            ent.E_Mail = txtmail.Text;
            ent.UserName = txtuser.Text;
            ent.Estado = CheckEstado.Checked;
            RutaImagen();
            ent.ImgEmpleado = HiddenField1.Value;

            var neg = new ClassNegEmpleado();
            bool resp = neg.ActualizaEmpleado(ent);
            return resp;
        }
        #endregion
        #region Subir Imagen
        public string RutaImagen()
        {
            bool fileOk = false;
            string respuesta = "";
            string ruta = Server.MapPath("~/Imagenes/ImagenesEmpleados/");

            try
            {
                if (FileUploadEmpleado.HasFile)
                {
                    string extension = Path.GetExtension(FileUploadEmpleado.FileName).ToLower();
                    string[] extensionValida = { ".jpg", ".png", ".gif", ".jpeg" };
                    for (int i = 0; i < extensionValida.Length; i++)
                    {

                        if (extension == extensionValida[i])
                        {
                            fileOk = true;
                        }

                        if (fileOk)
                        {
                            string nombreImg = FileUploadEmpleado.FileName.ToString();
                            FileUploadEmpleado.PostedFile.SaveAs(ruta + nombreImg);
                            HiddenField1.Value = "/Imagenes/ImagenesEmpleados/" + nombreImg;
                            respuesta = "subida";
                        }
                        else
                        {
                            HiddenField1.Value = "/Imagenes/Empleado.png";
                            respuesta = "Error";
                        }
                    }
                }
                else
                {
                    HiddenField1.Value = "/Imagenes/Empleado.png";
                    respuesta = "Error";
                }
                return respuesta;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #endregion
        //************************************************//

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenaGrid();
                LlenarGridInactivos();
                MultiViewEmpleado.ActiveViewIndex = 0;
            }
        }

        //************************************************//
        #region Botones
        protected void btnLista_Click(object sender, EventArgs e)
        {
            LlenaGrid();
            MultiViewEmpleado.ActiveViewIndex = 0;
            txtbuscar.Text = "";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            MultiViewEmpleado.ActiveViewIndex = 0;
            if (GuardaEmpleado())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exito!', 'Empleado Guardado Exitosamente', 'success');", true);
                LlenaGrid();
                txtbuscar.Text = "";
                RutaImagen();
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo guardar, ya Existe', 'error');", true);
            }
            LimpiarControles();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            MultiViewEmpleado.ActiveViewIndex = 0;
            if (ActualizaEmpleado())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exito!', 'Empleado Actualizado Exitosamente', 'success');", true);
                LlenaGrid();
                txtbuscar.Text = "";
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo Actualizar', 'error');", true);
            }
            LimpiarControles();
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            LlenaGridxNombre(txtbuscar.Text);
        }
        #endregion

        //************************************************//
        #region Comandos Botones de la Grilla
        protected void GridViewEmpleado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row=(GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int indice = row.RowIndex;
            int codigo = Convert.ToInt32(GridViewEmpleado.DataKeys[indice].Value);

            var neg =new ClassNegEmpleado();
            var ent = new ClassEntEmpleado();

            if (e.CommandName=="cmdeditar")
            {
                ent = neg.MuestraEmpleadoxID(codigo);
                txtcodigo.Text = ent.IDEmpleado.ToString();
                txtnombre.Text=ent.Nombre;
                txtapepat.Text=ent.Apellido1;
                txtapemat.Text=ent.Apellido2;
                txtdirexion.Text=ent.Direccion;
                txttelefono.Text=ent.Telefono;
                txtmail.Text=ent.E_Mail;
                txtuser.Text=ent.UserName;
                CheckEstado.Checked=Convert.ToBoolean(ent.Estado);
                HiddenField1.Value=ent.ImgEmpleado;
                Imageemploy.ImageUrl=HiddenField1.Value;

                MultiViewEmpleado.ActiveViewIndex=1;

                 btnGuardar.Visible = false;

                btnActualizar.Enabled = true;
                btnActualizar.Visible = true;

                btncancelar.Visible = true;
            }
            if (e.CommandName=="cmdeliminar")
            {
                neg.DardeBaja(codigo);
                LlenarGridInactivos();
            }
        }
        #endregion

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            MultiViewEmpleado.ActiveViewIndex = 0;
            txtbuscar.Text = "";
            btnActualizar.Visible = false;
            btncancelar.Visible = false;
            btnGuardar.Visible = true;
            btnGuardar.Enabled = true;
        }

        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            MultiViewEmpleado.ActiveViewIndex = 1;
            txtnombre.Text = "";
            txtapepat.Text = "";
            txtapemat.Text = "";
            txtdirexion.Text = "";
            txttelefono.Text = "";
            txtmail.Text = "";
            txtuser.Text = "";
            btnActualizar.Visible = false;
            btncancelar.Visible = false;
            btnGuardar.Visible = true;
            btnGuardar.Enabled = true;
        }

        protected void GridViewEmpleado_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewEmpleado.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropEmp");
                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("lblArtoPageOf");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GridViewEmpleado.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GridViewEmpleado.PageIndex)
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
                    int currentPage = GridViewEmpleado.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GridViewEmpleado.PageCount.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void DropEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewEmpleado.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropEmp");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...           
                GridViewEmpleado.PageIndex = pageList.SelectedIndex;
                //------------------------------
                LlenaGrid();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        protected void btninactivos_Click(object sender, EventArgs e)
        {
            MultiViewEmpleado.ActiveViewIndex = 2;
            LlenarGridInactivos();
        }

        protected void btnActivos_Click(object sender, EventArgs e)
        {
            MultiViewEmpleado.ActiveViewIndex = 0;
            LlenaGrid();
        }

        protected void btnnew_Click(object sender, EventArgs e)
        {
            MultiViewEmpleado.ActiveViewIndex = 1;
        }

        protected void GVInactivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int indice = row.RowIndex;
            int codigo = Convert.ToInt32(GVInactivos.DataKeys[indice].Value);

            var neg = new ClassNegEmpleado();
            var ent = new ClassEntEmpleado();
            if (e.CommandName == "cmdrestaurar")
            {
                neg.Restaurar(codigo);
                LlenarGridInactivos();
            }
            if (e.CommandName == "cmdexterminar")
            {
                bool resp = neg.EiminaEmpleado(codigo);
                if (resp)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Advertencia!', 'Departamento Eliminado', 'warning');", true);
                    LlenarGridInactivos();
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'Acurrio un problema, no se elimino', 'error');", true);
                }
            }
        }

        protected void GVInactivos_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GVInactivos.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropInactivos");
                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("lblfininactivos");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GVInactivos.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GVInactivos.PageIndex)
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
                    int currentPage = GVInactivos.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GVInactivos.PageCount.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void DropInactivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GVInactivos.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropInactivos");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...           
                GVInactivos.PageIndex = pageList.SelectedIndex;
                //------------------------------
                LlenarGridInactivos();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        protected void btnbuscainactivos_Click(object sender, EventArgs e)
        {
            LleneGridXNombreInactivos(txtbuscainactivos.Text.Trim());
        }
    }
}