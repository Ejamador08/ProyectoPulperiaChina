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
    public partial class Municipio : System.Web.UI.Page
    {
        #region Metodos
        #region Guarda Municipio
        public bool GuardaMunicipio()
        {
            var mun = new ClassEntMunicipio();
            mun.Nombre_Municipio = txtNombre.Text;
            mun.ID_Departamento = Convert.ToInt32(DropDepto.SelectedValue);
            mun.Estado = Convert.ToBoolean(CheckEstado.Checked);

            var munGuarda = new ClassNegMunicipio();
            if (munGuarda.BuscaMunicipioDuplicado(mun).Count<1)
	            {
		            bool resp = munGuarda.GuardaMunicipio(mun);
                    return resp; 
	            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo guardar', 'error');", true);
                return false;
            }
        }
        #endregion

        #region Llenar Drop Departamento
        public void LlenarDropDepto()
        {
            var depto = new ClassNegDepartamento();
            DropDepto.DataSource = depto.MuestraDepto();
            DropDepto.DataValueField = "ID_Departamento";
            DropDepto.DataTextField = "Nombre_Depto";
            DropDepto.DataBind();
        }
        #endregion

        #region Actualiza Municipio
        public bool ActualizaMunicipio()
        {
            var mun = new ClassEntMunicipio();
            mun.ID_Municipio = Convert.ToInt32(txtCodigo.Text);
            mun.Nombre_Municipio = txtNombre.Text;
            mun.ID_Departamento = Convert.ToInt32(DropDepto.SelectedValue);
            mun.Estado = Convert.ToBoolean(CheckEstado.Checked);


            var munActualiza = new ClassNegMunicipio();
            bool resp = munActualiza.ActualizaMunicipio(mun);
            return resp;
        }
        #endregion

        #region Llenar Grid Municipio
        public void LlenarGrid()
        {
            var depto = new ClassNegMunicipio();
            GridViewMunicipios.DataSource = depto.MostrarMunicipio();
            GridViewMunicipios.DataBind();
        }
        #endregion

        public void LLenarGridInactivos()
        {
            var neg = new ClassNegMunicipio();
            GVInactivos.DataSource = neg.MuestraMunicipioInactivos();
            GVInactivos.DataBind();
        }

        #region Muestra Municipio x Nombre
        public void MuestraMunicipio(string munic)
        {
            var mun = new ClassNegMunicipio();
            GridViewMunicipios.DataSource = mun.MostrarMunicipioxNombre(munic);
            GridViewMunicipios.DataBind();
        }
        #endregion

        public void MuestraMunicipioInactivos(string name)
        {
            var neg = new ClassNegMunicipio();
            GVInactivos.DataSource = neg.MostrarMunicipioxNombreInactivos(name);
            GVInactivos.DataBind();
        }

        #region Limpiar Controles
        public void LimpiarControles()
        {
            txtNombre.Text = "";
        }
        #endregion
        #endregion
        //************************************************//

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiViewMunicipio.ActiveViewIndex = 0;
                LlenarDropDepto();
                LlenarGrid();
                LLenarGridInactivos();
            }
            
        }

        //************************************************//
        #region Botones
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //GuardaMunicipio();
            //LimpiarControles();
            MultiViewMunicipio.ActiveViewIndex = 0;
            if (GuardaMunicipio())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exito!', 'Municipio Guardado Exitosamente', 'success');", true);
                LlenarGrid();
                txtBuscar.Text = "";
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo guardar, ya Existe', 'error');", true);
            }
            LimpiarControles();
        }

        protected void btnLista_Click(object sender, EventArgs e)
        {
            MultiViewMunicipio.ActiveViewIndex = 0;
            LlenarGrid();
            txtBuscar.Text = "";
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            MultiViewMunicipio.ActiveViewIndex = 0;
            if (ActualizaMunicipio())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exito!', 'Municipio Actualizado Exitosamente', 'success');", true);
                LlenarGrid();
                txtBuscar.Text = "";
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo Actualizar', 'error');", true);
            }
            LimpiarControles();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            MuestraMunicipio(txtBuscar.Text);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            MultiViewMunicipio.ActiveViewIndex = 0;
        }
        #endregion

        //************************************************//
        #region Comandos Botones de la Grilla
        protected void GridViewMunicipios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int indice = row.RowIndex;
            int codigo = Convert.ToInt32(GridViewMunicipios.DataKeys[indice].Value);

            var mun = new ClassNegMunicipio();
            var mun1 = new ClassEntMunicipio();

            if (e.CommandName=="cmdEditar")
            {
                mun1 = mun.MostrarMunicipioxID(codigo);

                txtCodigo.Text = mun1.ID_Municipio.ToString();
                txtNombre.Text = mun1.Nombre_Municipio;
                DropDepto.SelectedValue = mun1.ID_Municipio.ToString();
                CheckEstado.Checked = Convert.ToBoolean(mun1.Estado);

                MultiViewMunicipio.ActiveViewIndex = 1;

                btnCancelar.Visible = true;

                btnGuardar.Enabled = false;
                btnGuardar.Visible = false;

                btnActualizar.Enabled = true;
                btnActualizar.Visible = true;    
            }
            if (e.CommandName=="cmdEliminar")
            {
                mun.DardeBaja(codigo);
                LlenarGrid();
            }
        }
        #endregion

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            MultiViewMunicipio.ActiveViewIndex = 1;
            txtBuscar.Text = "";
            btnActualizar.Visible = false;
            btnCancelar.Visible = false;
            btnGuardar.Visible = true;
            btnGuardar.Enabled = true;
        }

        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            MultiViewMunicipio.ActiveViewIndex = 1;
            txtNombre.Text = "";
            btnActualizar.Visible = false;
            btnCancelar.Visible = false;
            btnGuardar.Visible = true;
            btnGuardar.Enabled = true;
        }

        protected void GridViewMunicipios_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewMunicipios.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropMun");
                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("lblArtoPageOf");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GridViewMunicipios.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GridViewMunicipios.PageIndex)
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
                    int currentPage = GridViewMunicipios.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GridViewMunicipios.PageCount.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void DropMun_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewMunicipios.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropMun");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...           
                GridViewMunicipios.PageIndex = pageList.SelectedIndex;
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
            MultiViewMunicipio.ActiveViewIndex = 2;
            LLenarGridInactivos();
        }

        protected void btnactivos_Click(object sender, EventArgs e)
        {
            MultiViewMunicipio.ActiveViewIndex = 0;
            LlenarGrid();
        }

        protected void btnnew_Click(object sender, EventArgs e)
        {
            MultiViewMunicipio.ActiveViewIndex = 1;
        }

        protected void btnbuscainactivos_Click(object sender, EventArgs e)
        {
            MuestraMunicipioInactivos(txtbuscainactivos.Text.Trim());
        }

        protected void GVInactivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int indice = row.RowIndex;
            int codigo = Convert.ToInt32(GridViewMunicipios.DataKeys[indice].Value);

            var mun = new ClassNegMunicipio();
            var mun1 = new ClassEntMunicipio();
            if (e.CommandName == "cmdrestaurar")
            {
                mun.Restaurar(codigo);
                LLenarGridInactivos();
            }
            if (e.CommandName == "cmdexterminar")
            {
                bool resp = mun.EliminaMunicipio(codigo);
                if (resp)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Advertencia!', 'Municipi Eliminado', 'warning');", true);
                    LLenarGridInactivos();
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
                LLenarGridInactivos();
            }
            catch (Exception)
            {
                //throw;
            }
        }
    }
}