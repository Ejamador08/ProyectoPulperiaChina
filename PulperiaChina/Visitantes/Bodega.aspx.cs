using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaNegocio;
using CapaEntidad;

namespace PulperiaChina.Visitantes
{
    public partial class Bodega : System.Web.UI.Page
    {
        #region Metodos
        #region LLenar Grid
        public void llenarGrid()
        {
            var neg = new ClassNegBodega();
            GridViewBodegas.DataSource = neg.MuestraBodega();
            GridViewBodegas.DataBind();
        }
        #endregion

        public void LlenarGridInactivos()
        {
            var neg = new ClassNegBodega();
            GVInactivos.DataSource = neg.MuestraBodegaInactivos();
            GVInactivos.DataBind();
        }

        #region Llenar Grid Busca x Nombre
        public void LlenarGridxNombre(string name)
        {
            var neg = new ClassNegBodega();
            GridViewBodegas.DataSource = neg.MuestraBodegaxNombre(name);
            GridViewBodegas.DataBind();
        }
        #endregion

        public void LlenarGridXNombreInactivos(string name)
        {
            var neg = new ClassNegBodega();
            GVInactivos.DataSource = neg.MuestraBodegaxNombreInactivos(name);
            GVInactivos.DataBind();
        }

        #region Guarda Bodega
        public bool GuardaBodega()
        {
            var ent = new ClassEntBodega();
            ent.Nombre_Bodega = txtnombre.Text;
            ent.Descripcion = txtdescripcion.Text;
            ent.Estado = CheckEstado.Checked;

            var neg = new ClassNegBodega();
            if (neg.BuscaBodegaDuplicadas(ent).Count<1)
            {
                bool resp = neg.GuardaBodega(ent);
                return resp;
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo guardar', 'error');", true);
                return false;
            }
        }
        #endregion
        #region Actualiza Bodega
        public bool ActualizaBodega()
        {
            var ent = new ClassEntBodega();
            ent.ID_Bodega = Convert.ToInt32(txtcodigo.Text);
            ent.Nombre_Bodega = txtnombre.Text;
            ent.Descripcion = txtdescripcion.Text;
            ent.Estado = CheckEstado.Checked;

            var neg = new ClassNegBodega();
            bool resp = neg.ActualizaBodega(ent);
            return resp;
        }
        #endregion
        #region Limpiar Controles
        public void LimpiarControles()
        {
            txtnombre.Text = "";
            txtdescripcion.Text = "";
        }
        #endregion
        #endregion
        //************************************************//

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarGrid();
                LlenarGridInactivos();
                MultiViewBodega.ActiveViewIndex = 0;
            }
        }

        //************************************************//
        #region Botones
        protected void btnlista_Click(object sender, EventArgs e)
        {
            MultiViewBodega.ActiveViewIndex = 0;
            llenarGrid();
            txtbuscar.Text = "";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            MultiViewBodega.ActiveViewIndex = 0;
            if (GuardaBodega())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exito!', 'Bodega Guardada Exitosamente', 'success');", true);
                llenarGrid();
                txtbuscar.Text = "";
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo guardar, ya Existe', 'error');", true);
            }
            LimpiarControles();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            MultiViewBodega.ActiveViewIndex = 0;
            if (ActualizaBodega())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exito!', 'Bodega Actualizada Exitosamente', 'success');", true);
                llenarGrid();
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
            LlenarGridxNombre(txtbuscar.Text);
        }
        #endregion

        //************************************************//
        #region Comando Botones de la grilla
        protected void GridViewBodegas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int indice = row.RowIndex;
            int codigo = Convert.ToInt32(GridViewBodegas.DataKeys[indice].Value);

            var neg = new ClassNegBodega();
            var ent = new ClassEntBodega();
            if (e.CommandName=="cmdeditar")
            {
                ent = neg.MuestraBodegaxID(codigo);
                txtcodigo.Text = ent.ID_Bodega.ToString();
                txtnombre.Text = ent.Nombre_Bodega;
                txtdescripcion.Text = ent.Descripcion;
                CheckEstado.Checked = Convert.ToBoolean(ent.Estado);

                MultiViewBodega.ActiveViewIndex = 1;

                btnGuardar.Visible = false;

                btnActualizar.Visible = true;
                btnActualizar.Enabled = true;

                btncancact.Visible = true;
            }
            
            if (e.CommandName=="cmdeliminar")
	        {
                neg.DardeBaja(codigo);
                llenarGrid();
	        }
        }
        #endregion

        protected void btncancact_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            MultiViewBodega.ActiveViewIndex = 0;
            txtbuscar.Text = "";
            btnActualizar.Visible=false;
            btncancact.Visible = false;
            btnGuardar.Visible = true;
            btnGuardar.Enabled = true;
        }

        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            MultiViewBodega.ActiveViewIndex = 1;
            txtnombre.Text = "";
            txtdescripcion.Text = "";
            btnActualizar.Visible = false;
            btncancact.Visible = false;
            btnGuardar.Visible = true;
            btnGuardar.Enabled = true;
        }

        protected void GridViewBodegas_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewBodegas.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropBodega");
                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("lblfin");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GridViewBodegas.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GridViewBodegas.PageIndex)
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
                    int currentPage = GridViewBodegas.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GridViewBodegas.PageCount.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void DropBodega_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewBodegas.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropBodega");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...           
                GridViewBodegas.PageIndex = pageList.SelectedIndex;
                //------------------------------
                llenarGrid();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        protected void btninactivos_Click(object sender, EventArgs e)
        {
            MultiViewBodega.ActiveViewIndex = 2;
            LlenarGridInactivos();
        }

        protected void btnactivos_Click(object sender, EventArgs e)
        {
            MultiViewBodega.ActiveViewIndex = 0;
            llenarGrid();
        }

        protected void btnnew_Click(object sender, EventArgs e)
        {
            MultiViewBodega.ActiveViewIndex = 1;
        }

        protected void btnbuscainactivos_Click(object sender, EventArgs e)
        {
            LlenarGridXNombreInactivos(txtbuscainactivos.Text.Trim());
        }

        protected void GVInactivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int indice = row.RowIndex;
            int codigo = Convert.ToInt32(GVInactivos.DataKeys[indice].Value);

            var neg = new ClassNegBodega();
            var ent = new ClassEntBodega();
            if (e.CommandName == "cmdrestaurar")
            {
                neg.Restaurar(codigo);
                LlenarGridInactivos();
            }
            if (e.CommandName == "cmdexterminar")
            {
                bool resp = neg.EliminaBodega(codigo);
                if (resp)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Advertencia!', 'Bodega Eliminada', 'warning');", true);
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
    }
}