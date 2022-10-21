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
    public partial class Departamento : System.Web.UI.Page
    {
        #region Metodos
        #region Guarda Departamento
        public bool GuardaDepto()
        {
            ClassEntDepartamento depto = new ClassEntDepartamento();
            depto.Nombre_Depto = txtNombre.Text;
            depto.Estado = CheckEstado.Checked;


            ClassNegDepartamento deptoGuarda = new ClassNegDepartamento();
            if (deptoGuarda.BuscaDepartamentoDuplicado(depto).Count<1)
            {
                bool resp = deptoGuarda.GuardaDepto(depto);
                return resp;
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo guardar', 'error');", true);
                return false;
            }
        }
        #endregion

        #region Llenar Grid
        public void LlearGridDepto()
        {
            ClassNegDepartamento depto = new ClassNegDepartamento();
            GridViewDepartamento.DataSource = depto.MuestraDepto();
            GridViewDepartamento.DataBind();
        }
        #endregion

        public void llenarGridInactivos()
        {
            var neg = new ClassNegDepartamento();
            GVInactivos.DataSource = neg.MuestraDeptoInactivos();
            GVInactivos.DataBind();
        }

        #region Actualizar Departamento
        public bool ActualizaDepto()
        {
            var depto = new ClassEntDepartamento(); 
            depto.ID_Departamento = Convert.ToInt32(txtCodigo.Text);
            depto.Nombre_Depto = txtNombre.Text;
            depto.Estado = Convert.ToBoolean(CheckEstado.Checked);

            var deptoActualiza = new ClassNegDepartamento();
            bool resp = deptoActualiza.ActualizaDepto(depto);
            return resp;
        }
        #endregion

        #region Muestra Departamento x Nombre
        public void MuestraDeptoxNombre(string depart)
        {
            var depa = new ClassNegDepartamento();
            GridViewDepartamento.DataSource = depa.MuestraDeptoxNombre(depart);
            GridViewDepartamento.DataBind();
        }
        #endregion

        public void MuestraDeptoXNombreInactivos(string name)
        {
            var neg = new ClassNegDepartamento();
            GVInactivos.DataSource = neg.MuestraDeptoxNombreInactivos(name);
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
                MultiViewDepartamento.ActiveViewIndex = 0;
                LlearGridDepto();
                llenarGridInactivos();
            }
           
        }

        //************************************************//
        #region Botones
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //GuardaDepto();
            //LimpiarControles();
            MultiViewDepartamento.ActiveViewIndex = 0;
            if (GuardaDepto())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exito!', 'Departamento Guardado Exitosamente', 'success');", true);
                LlearGridDepto();
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
            MultiViewDepartamento.ActiveViewIndex = 0;
            LlearGridDepto();
            txtBuscar.Text = "";
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            MultiViewDepartamento.ActiveViewIndex = 0;
            if (ActualizaDepto())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exito!', 'Departamento Actualizado Exitosamente', 'success');", true);
                LlearGridDepto();
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
            MuestraDeptoxNombre(txtBuscar.Text);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            MultiViewDepartamento.ActiveViewIndex = 0;
        }
        #endregion

        //************************************************//
        #region Comandos Botones de la Grilla
        protected void GridViewDepartamento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int indice = row.RowIndex;
            int codigo = Convert.ToInt32(GridViewDepartamento.DataKeys[indice].Value);

            var depto = new ClassNegDepartamento();
            var depto1 =new ClassEntDepartamento();

            if (e.CommandName=="cmdEditar")
            {
                depto1 = depto.MuestraDeptoxID(codigo);
                txtCodigo.Text = depto1.ID_Departamento.ToString();
                txtNombre.Text = depto1.Nombre_Depto;
                CheckEstado.Checked = Convert.ToBoolean(depto1.Estado);

                MultiViewDepartamento.ActiveViewIndex = 1;

                btnGuardar.Enabled = false;
                btnGuardar.Visible = false;

                btnActualizar.Enabled = true;
                btnActualizar.Visible = true;

                btncancelar.Visible = true;
            }
            if (e.CommandName == "cmdEliminar")
            {
                depto.DardeBaja(codigo);
                LlearGridDepto();
                
            }
        }
        #endregion

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            MultiViewDepartamento.ActiveViewIndex = 0;
            txtBuscar.Text = "";
            btnActualizar.Visible = false;
            btncancelar.Visible = false;
            btnGuardar.Visible = true;
            btnGuardar.Enabled = true;
        }

        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            MultiViewDepartamento.ActiveViewIndex = 1;
            txtNombre.Text = "";
            btnActualizar.Visible = false;
            btncancelar.Visible = false;
            btnGuardar.Visible = true;
            btnGuardar.Enabled = true;
        }

        protected void GridViewDepartamento_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewDepartamento.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropDepto");
                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("lblArtoPageOf");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GridViewDepartamento.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GridViewDepartamento.PageIndex)
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
                    int currentPage = GridViewDepartamento.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GridViewDepartamento.PageCount.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void DropDepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewDepartamento.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropDepto");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...           
                GridViewDepartamento.PageIndex = pageList.SelectedIndex;
                //------------------------------
                LlearGridDepto();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        protected void btninactivos_Click(object sender, EventArgs e)
        {
            MultiViewDepartamento.ActiveViewIndex = 2;
            llenarGridInactivos();
        }

        protected void btnnew_Click(object sender, EventArgs e)
        {
            MultiViewDepartamento.ActiveViewIndex = 1;
        }

        protected void btnactivos_Click(object sender, EventArgs e)
        {
            MultiViewDepartamento.ActiveViewIndex = 0;
            LlearGridDepto();
        }

        protected void btnbuscainactivos_Click(object sender, EventArgs e)
        {
            MuestraDeptoXNombreInactivos(txtbuscainactivos.Text.Trim());
        }

        protected void GVInactivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int indice = row.RowIndex;
            int codigo = Convert.ToInt32(GVInactivos.DataKeys[indice].Value);

            var depto = new ClassNegDepartamento();
            var depto1 = new ClassEntDepartamento();
            if (e.CommandName == "cmdrestaurar")
            {
                depto.Restaurar(codigo);
                llenarGridInactivos();
            }
            if (e.CommandName == "cmdexterminar")
            {
                bool resp = depto.EliminaDepto(codigo);
                if (resp)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Advertencia!', 'Departamento Eliminado', 'warning');", true);
                    llenarGridInactivos();
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
                llenarGridInactivos();
            }
            catch (Exception)
            {
                //throw;
            }
        }
    }
}