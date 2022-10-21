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
    public partial class Marca : System.Web.UI.Page
    {
        #region Metodos
        #region Limpiar Controles
        public void LimpiarControles()
        {
            txtnombre.Text = "";
            //CheckEstado.Checked = unchecked(CheckEstado.Checked);
        }
        #endregion
        #region Llena Grid
        public void LlenarGrid()
        {
            var neg = new ClassNegMarca();
            GridViewMarca.DataSource = neg.MuestraMarca();
            GridViewMarca.DataBind();
        }
        #endregion
        public void LlenarGridInactivos()
        {
            var neg = new ClassNegMarca();
            GVInactivos.DataSource = neg.MuestraMarcaInactivas();
            GVInactivos.DataBind();
        }
        #region Llenar Grid x Nombre
        public void LlenarGridxNombre(string name)
        {
            var neg = new ClassNegMarca();
            GridViewMarca.DataSource = neg.MuestraMarcaxNombre(name);
            GridViewMarca.DataBind();
        }
        #endregion
        public void LlenarGridxNombreInactivas(string name)
        {
            var neg = new ClassNegMarca();
            GVInactivos.DataSource = neg.MuestraMarcaxNombreInactivas(name);
            GVInactivos.DataBind();
        }
        #region guarda
        public bool GuardaMarca()
        {
            var ent=new ClassEntMarca();
            ent.Nombre_Marca = txtnombre.Text;
            ent.Estado = CheckEstado.Checked;

            var neg = new ClassNegMarca();
            if (neg.BuscaMarcaDuplicada(ent).Count<1)
            {
                bool resp = neg.GuardaMarca(ent);
                return resp;
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo guardar', 'error');", true);
                return false;
            }
        }
        #endregion
        #region Actualiza Marca
        public bool ActualizaMarca()
        {
            var ent = new ClassEntMarca();
            ent.IDMarca = Convert.ToInt32(txtcodigo.Text);
            ent.Nombre_Marca = txtnombre.Text;
            ent.Estado = Convert.ToBoolean(CheckEstado.Checked);

            var neg = new ClassNegMarca();
            bool resp = neg.ActualizaMarca(ent);
            return resp;
        }
        #endregion
        #endregion
        //************************************************//

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                LlenarGridInactivos();
                MultiViewMarca.ActiveViewIndex = 0;
            }
        }

        //************************************************//
        #region Botones
        protected void btnLista_Click(object sender, EventArgs e)
        {
            LlenarGrid();
            MultiViewMarca.ActiveViewIndex = 0;
            txtbuscar.Text = "";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            MultiViewMarca.ActiveViewIndex = 0;
            if (GuardaMarca())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exito!', 'Marca Guardada Exitosamente', 'success');", true);
                LlenarGrid();
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
            MultiViewMarca.ActiveViewIndex = 0;
            if (ActualizaMarca())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exito!', 'Marca Actualizada Exitosamente', 'success');", true);
                LlenarGrid();
                txtbuscar.Text = "";
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo Actualizar', 'error');", true); 
            }
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            LlenarGridxNombre(txtbuscar.Text);
        }
        #endregion

        //************************************************//
        #region Comandos Botones de la grilla
        protected void GridViewMarca_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row=(GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int indice = row.RowIndex;
            int codigo = Convert.ToInt32(GridViewMarca.DataKeys[indice].Value);

            var neg = new ClassNegMarca();
            var ent = new ClassEntMarca();
            if (e.CommandName=="cmdeditar")
            {
                ent = neg.MuestraMarcaxID(codigo);
                txtcodigo.Text = ent.IDMarca.ToString();
                txtnombre.Text = ent.Nombre_Marca;
                CheckEstado.Checked = Convert.ToBoolean(ent.Estado);

                MultiViewMarca.ActiveViewIndex = 1;

                btnGuardar.Visible = false;

                btnActualizar.Enabled = true;
                btnActualizar.Visible = true;

                btncancelar.Visible = true;
            }
            if (e.CommandName == "cmdeliminar")
            {
                neg.DardeBaja(codigo);
                LlenarGrid();
            }

        }
        #endregion

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            MultiViewMarca.ActiveViewIndex = 0;
            txtbuscar.Text = "";
            txtnombre.Text = "";
            btnActualizar.Visible = false;
            btncancelar.Visible = false;
            btnGuardar.Visible = true;
            btnGuardar.Enabled = true;
        }

        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            MultiViewMarca.ActiveViewIndex = 1;
            txtnombre.Text = "";
            btnActualizar.Visible = false;
            btncancelar.Visible = false;
            btnGuardar.Visible = true;
            btnGuardar.Enabled = true;
        }

        protected void GridViewMarca_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewMarca.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropMArca");
                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("lblArtoPageOf");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GridViewMarca.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GridViewMarca.PageIndex)
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
                    int currentPage = GridViewMarca.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GridViewMarca.PageCount.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void DropMArca_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewMarca.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropMArca");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...           
                GridViewMarca.PageIndex = pageList.SelectedIndex;
                //------------------------------
                LlenarGrid();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        protected void btninactivos_Click(object sender, EventArgs e)
        {
            MultiViewMarca.ActiveViewIndex = 2;
            LlenarGridInactivos();
        }

        protected void btnactivos_Click(object sender, EventArgs e)
        {
            MultiViewMarca.ActiveViewIndex = 0;
            LlenarGrid();
        }

        protected void btnnew_Click(object sender, EventArgs e)
        {
            MultiViewMarca.ActiveViewIndex = 1;
        }

        protected void btnbuscainactivos_Click(object sender, EventArgs e)
        {
            LlenarGridxNombreInactivas(txtbuscainactivos.Text.Trim());
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
            int codigo = Convert.ToInt32(GVInactivos.DataKeys[indice].Value);

            var neg = new ClassNegMarca();
            var ent = new ClassEntMarca();
            if (e.CommandName == "cmdrestaurar")
            {
                neg.Restaurar(codigo);
                LlenarGridInactivos();
            }
            if (e.CommandName == "cmdexterminar")
            {
                bool resp = neg.EliminaMarca(codigo);
                if (resp)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Advertencia!', 'Marca Eliminada', 'warning');", true);
                    LlenarGrid();
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
                LlenarGridInactivos();
            }
            catch (Exception)
            {
                //throw;
            }
        }
    }
}