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
    public partial class Categoria : System.Web.UI.Page
    {
        #region Metodos
        #region Llenar Grid
        public void LlenarGrid()
        {
            ClassNegCategoria cat = new ClassNegCategoria();
            GridViewCategorias.DataSource = cat.MuestraCategoria();
            GridViewCategorias.DataBind();
        }
        #endregion

        public void LlenarGridInactivos()
        {
            var neg = new ClassNegCategoria();
            GVInactivos.DataSource = neg.MostrarCategoriaInactivas();
            GVInactivos.DataBind();
        }

        #region Guardar Categoria
        public bool GuardaCategoria()
        {
            ClassEntCategoria cat = new ClassEntCategoria();
            cat.Nombre_Categoria = txtNombre.Text;
            cat.Descripcion_Categoria = txtDescripcion.Text;
            cat.Estado = CheckEstado.Checked;


            ClassNegCategoria catGuarda = new ClassNegCategoria();
            if (catGuarda.BuscarCategoriasDuplicadas(cat).Count<1)
            {
                bool resp = catGuarda.GuardaCategoria(cat);
                return resp;
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo guardar', 'error');", true);
                return false;
            } 
        }
        #endregion
        
        #region Actualizar Categoria
        public bool ActualizarCategoria()
        {
            var cat = new ClassEntCategoria();
            cat.ID_Categoria = Convert.ToInt32(txtCodigo.Text);
            cat.Nombre_Categoria = txtNombre.Text;
            cat.Descripcion_Categoria = txtDescripcion.Text;
            cat.Estado = Convert.ToBoolean(CheckEstado.Checked);

            var catActualiza = new ClassNegCategoria();
            bool Resp = catActualiza.ActualizaCategoria(cat);
            return Resp;
        }
        #endregion

        #region Muestra Categoria x Nombre referencia al btn Buscar
        private void BuscarCategoria(string category)
        {
            var cat = new ClassNegCategoria();
            GridViewCategorias.DataSource = cat.MostrarCategoriaxNombre(category);
            GridViewCategorias.DataBind();
        }

        #endregion

        public void BuscaCategoriaInactiva(string name)
        {
            var neg = new ClassNegCategoria();
            GVInactivos.DataSource = neg.MostrarCategoriaxNombreInactivos(name);
            GVInactivos.DataBind();
        }

        #region Limpiar Controles
        public void LimpiaControles()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
        }
        #endregion
        #endregion
        //************************************************//

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiViewCategorias.ActiveViewIndex = 0;
                LlenarGrid();
                LlenarGridInactivos();
            }
        }

        //************************************************//
        #region Botones

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //GuardaCategoria();
            //LimpiaControles();
            MultiViewCategorias.ActiveViewIndex = 0;
            if (GuardaCategoria())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exito!', 'Categoria Guardada Exitosamente', 'success');", true);
                LlenarGrid();
                txtBuscar.Text = "";
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo guardar, ya Existe', 'error');", true);
            }
            LimpiaControles();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            MultiViewCategorias.ActiveViewIndex = 0;
            if (ActualizarCategoria())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exito!', 'Categoria Actualizada Exitosamente', 'success');", true);
                LlenarGrid();
                txtBuscar.Text = "";
            }
            else
	        {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo Actualizar', 'error');", true);
	        }
            LimpiaControles();
        }

        protected void btnLista_Click(object sender, EventArgs e)
        {
            MultiViewCategorias.ActiveViewIndex = 0;
            LlenarGrid();
            txtBuscar.Text = "";
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCategoria(txtBuscar.Text);
            txtBuscar.Text = "";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categoria.aspx");
        }

        #endregion


        //************************************************//
        #region Comando Botonesde la Grilla
        protected void GridViewCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int indice = row.RowIndex;
            int codigo = Convert.ToInt32(GridViewCategorias.DataKeys[indice].Value);

            ClassNegCategoria cat = new ClassNegCategoria();
            ClassEntCategoria cat1 = new ClassEntCategoria();
            if (e.CommandName=="cmdEditar")
            {
                cat1 = cat.MostrarCategoriaxID(codigo);
                txtCodigo.Text = cat1.ID_Categoria.ToString();
                txtNombre.Text = cat1.Nombre_Categoria;
                txtDescripcion.Text = cat1.Descripcion_Categoria;
                CheckEstado.Checked = Convert.ToBoolean(cat1.Estado);

                MultiViewCategorias.ActiveViewIndex = 1;

                btnGuardar.Enabled = false;
                btnGuardar.Visible = false;

                btnActualizar.Enabled = true;
                btnActualizar.Visible = true;

                btncancelar.Visible=true;
            }
            if (e.CommandName=="cmdEliminar")
            {
                cat.DardeBaja(codigo);
                LlenarGrid();
            }
        }
        #endregion

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            LimpiaControles();
            MultiViewCategorias.ActiveViewIndex = 0;
            txtBuscar.Text = "";
            btnActualizar.Visible = false;
            btncancelar.Visible = false;
            btnGuardar.Visible = true;
            btnGuardar.Enabled = true;
        }

        protected void btnnuevo_Click1(object sender, EventArgs e)
        {
            MultiViewCategorias.ActiveViewIndex = 1;
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            btnActualizar.Visible = false;
            btncancelar.Visible=false;
            btnGuardar.Visible=true;
            btnGuardar.Enabled = true;

        }

        protected void GridViewCategorias_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewCategorias.BottomPagerRow; 
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropCAt");
                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("lblArtoPageOf");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GridViewCategorias.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GridViewCategorias.PageIndex)
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
                    int currentPage = GridViewCategorias.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GridViewCategorias.PageCount.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void DropCAt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewCategorias.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropCAt");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...           
                GridViewCategorias.PageIndex = pageList.SelectedIndex;
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
            MultiViewCategorias.ActiveViewIndex = 2;
            LlenarGridInactivos();
        }

        protected void btnactivos_Click(object sender, EventArgs e)
        {
            MultiViewCategorias.ActiveViewIndex = 0;
            LlenarGrid();
        }

        protected void btnnew_Click(object sender, EventArgs e)
        {
            MultiViewCategorias.ActiveViewIndex = 1;
        }

        protected void btnbuscainactivos_Click(object sender, EventArgs e)
        {
            BuscaCategoriaInactiva(txtbuscainactivos.Text.Trim());
        }

        protected void GVInactivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int indice = row.RowIndex;
            int codigo = Convert.ToInt32(GVInactivos.DataKeys[indice].Value);

            ClassNegCategoria cat = new ClassNegCategoria();
            ClassEntCategoria cat1 = new ClassEntCategoria();
            if (e.CommandName == "cmdrestaurar")
            {
                cat.Restaurar(codigo);
                LlenarGridInactivos();
            }
            if (e.CommandName == "cmdexterminar")
            {
                bool resp = cat.EliminarCategoria(codigo);
                if (resp)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Advertencia!', 'Categoria Eliminada', 'warning');", true);
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