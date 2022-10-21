using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaNegocio;
using CapaEntidad;
using System.IO;

namespace PulperiaChina.Visitantes
{
    public partial class Proveedor : System.Web.UI.Page
    {
        #region Metodos
        #region Llenar Gird
        public void LlenarGridProveedor()
        {
            var pro = new ClassNegProveedor();
            GridViewProveedores.DataSource = pro.MuestraProveedor();
            GridViewProveedores.DataBind();
        }
        #endregion

        public void LlenarGridProveedorInactivos()
        {
            var neg = new ClassNegProveedor();
            GVInactivos.DataSource = neg.MuestraProveedorInactivos();
            GVInactivos.DataBind();
        }

        #region Guarda Proveedor
        public bool GuardaProveedor()
        {
            var pro = new ClassEntProveedor();
            pro.Nombre_Proveedor = txtnombre.Text;
            pro.Telefono = txtTelefono.Text;
            pro.Direccion = txtDireccion.Text;
            pro.Email = txtmail.Text;
            pro.Estado = CheckEstado.Checked;
            subirImagen();
            pro.RutaLogo = HiddenField1.Value;


            var proGuarda = new ClassNegProveedor();
            if (proGuarda.BuscaProveedorDuplicado(pro).Count<1)
	            {
		            bool resp = proGuarda.GuardaProveedor(pro);
                    return resp;
	            }
            else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo guardar', 'error');", true);
                    return false;
                }
        }
        #endregion

        #region Actualizar Proveedor
        public bool ActualizaProveedor()
        {
            var pro = new ClassEntProveedor();
            pro.ID_Proveedor = Convert.ToInt32(txtCodigo.Text);
            pro.Nombre_Proveedor = txtnombre.Text;
            pro.Telefono = txtTelefono.Text;
            pro.Direccion = txtDireccion.Text;
            subirImagen();
            pro.RutaLogo = HiddenField1.Value;
            pro.Email = txtmail.Text;
            pro.Estado = Convert.ToBoolean(CheckEstado.Checked);


            var proActualiza = new ClassNegProveedor();
            bool resp = proActualiza.ActualizaProveedor(pro);
            return resp;
        }
        #endregion

        #region Muestra Proveedor x Nombre
        public void MostrarProvxNombre(string name)
        {
            var pro = new ClassNegProveedor();
            GridViewProveedores.DataSource = pro.MuestraProveedorxNombre(name);
            GridViewProveedores.DataBind();
        }
        #endregion

        public void MostrarProvxNombreInactivos(string name)
        {
            var neg = new ClassNegProveedor();
            GVInactivos.DataSource = neg.MuestraProveedorxNombreInactivos(name);
            GVInactivos.DataBind();
        }

        #region Limpiar Controles
        public void LimpiarControles()
        {
            txtnombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtmail.Text = "";
        }
        #endregion

        #region Subir Imagen Proveedor
        public string subirImagen()
        {
            bool fileOk = false;
            string respuesta = "";
            string ruta = Server.MapPath("/Imagenes/ImagenesProveedores/");
            try
            {
                if (FileUploadProveedor.HasFile)//Si tiene archivo seleccionado
                {
                    string extension = Path.GetExtension(FileUploadProveedor.FileName).ToLower();
                    string[] extensionValida = { ".jpg", ".png", ".gif", ".jpeg" };
                    for (int i = 0; i < extensionValida.Length; i++)
                    {

                        if (extension == extensionValida[i])
                        {
                            fileOk = true;
                        }

                        if (fileOk)
                        {
                            string nombreImg = FileUploadProveedor.FileName.ToString();
                            FileUploadProveedor.PostedFile.SaveAs(ruta + nombreImg);
                            HiddenField1.Value = "/Imagenes/ImagenesProveedores/" + nombreImg;
                            respuesta = "subida";
                        }
                        else
                        {
                            HiddenField1.Value = "/Imagenes/Proveedores.png";
                            respuesta = "Error";
                        }
                    }
                }
                else
                {
                    HiddenField1.Value = "/Imagenes/Proveedores.png";
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
                MultiViewProveedores.ActiveViewIndex = 0;
                LlenarGridProveedor();
                LlenarGridProveedorInactivos();
            }
        }

        //************************************************//
        #region Botones
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
        //    GuardaProveedor();
        //    LimpiarControles();
            MultiViewProveedores.ActiveViewIndex = 0;
            //lo haremos funcionar cuando validemos los valores duplicados
            if (GuardaProveedor())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exito!', 'Proveedor Guardado Exitosamente', 'success');", true);
                LlenarGridProveedor();
                txtBuscar.Text = "";
                subirImagen();
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo guardar, ya Existe', 'error');", true);
            }
            LimpiarControles();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            MultiViewProveedores.ActiveViewIndex = 0;
            if (ActualizaProveedor())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exito!', 'Proveedor Actualizado Exitosamente', 'success');", true);
                LlenarGridProveedor();
                txtBuscar.Text = "";
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo Actualizar', 'error');", true);
            }
            LimpiarControles();
        }

        protected void btnLista_Click(object sender, EventArgs e)
        {
            MultiViewProveedores.ActiveViewIndex = 0;
            LlenarGridProveedor();
            txtBuscar.Text = "";
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarProvxNombre(txtBuscar.Text);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            MultiViewProveedores.ActiveViewIndex = 0;
        }
        #endregion

        //************************************************//
        #region Comando Botnes de la Grilla
        protected void GridViewProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int indice = row.RowIndex;
            int codigo = Convert.ToInt32(GridViewProveedores.DataKeys[indice].Value);

            ClassNegProveedor pro = new ClassNegProveedor();
            ClassEntProveedor pro1 = new ClassEntProveedor();
            if (e.CommandName == "cmdEditar")
            {
                pro1 = pro.MuestraProveedorxID(codigo);
                txtCodigo.Text = pro1.ID_Proveedor.ToString();
                txtnombre.Text = pro1.Nombre_Proveedor;
                txtTelefono.Text = pro1.Telefono;
                txtDireccion.Text = pro1.Direccion;
                txtmail.Text = pro1.Email;
                CheckEstado.Checked = Convert.ToBoolean(pro1.Estado);
                HiddenField1.Value = pro1.RutaLogo;

                imgprov.ImageUrl = HiddenField1.Value;

                MultiViewProveedores.ActiveViewIndex = 1;

                btnGuardar.Enabled = false;
                btnGuardar.Visible = false;

                btncancelar.Visible = true;

                btnActualizar.Enabled = true;
                btnActualizar.Visible = true;
            }
            if (e.CommandName == "cmdEliminar")
            {
                pro.DardeBaja(codigo);
                LlenarGridProveedor();
            }

        }
        #endregion

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            MultiViewProveedores.ActiveViewIndex = 1;
            txtBuscar.Text = "";
            btnActualizar.Visible = false;
            btncancelar.Visible = false;
            btnGuardar.Visible = true;
            btnGuardar.Enabled = true;

        }

        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            MultiViewProveedores.ActiveViewIndex = 1;
            txtnombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtmail.Text = "";
            btnActualizar.Visible = false;
            btncancelar.Visible = false;
            btnGuardar.Visible = true;
            btnGuardar.Enabled = true;
        }

        protected void GridViewProveedores_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewProveedores.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropProv");
                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("lblArtoPageOf");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GridViewProveedores.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GridViewProveedores.PageIndex)
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
                    int currentPage = GridViewProveedores.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GridViewProveedores.PageCount.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void DropProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewProveedores.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropProv");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...           
                GridViewProveedores.PageIndex = pageList.SelectedIndex;
                //------------------------------
                LlenarGridProveedor();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        protected void btninactivos_Click(object sender, EventArgs e)
        {
            MultiViewProveedores.ActiveViewIndex = 2;
            LlenarGridProveedorInactivos();
        }

        protected void btnactivos_Click(object sender, EventArgs e)
        {
            MultiViewProveedores.ActiveViewIndex = 0;
            LlenarGridProveedor();
        }

        protected void btnnew_Click(object sender, EventArgs e)
        {
            MultiViewProveedores.ActiveViewIndex = 1;
        }

        protected void btnbuscainactivos_Click(object sender, EventArgs e)
        {
            MostrarProvxNombreInactivos(txtbuscarinactivos.Text.Trim());
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

        protected void GVInactivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int indice = row.RowIndex;
            int codigo = Convert.ToInt32(GridViewProveedores.DataKeys[indice].Value);

            ClassNegProveedor pro = new ClassNegProveedor();
            ClassEntProveedor pro1 = new ClassEntProveedor();
            if (e.CommandName == "cmdrestaurar")
            {
                pro.Restaurar(codigo);
                LlenarGridProveedorInactivos();
            }
            if (e.CommandName == "cmdexterminar")
            {
                bool resp = pro.EliminaProveedor(codigo);
                if (resp)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Advertencia!', 'Proveedor Eliminado', 'warning');", true);
                    LlenarGridProveedor();
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'Acurrio un problema, no se elimino', 'error');", true);
                }
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
                LlenarGridProveedorInactivos();
            }
            catch (Exception)
            {
                //throw;
            }
        }
    }
}