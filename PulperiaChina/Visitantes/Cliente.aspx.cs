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
    public partial class Cliente : System.Web.UI.Page
    {
        #region Metodos
        #region Llenar Grid Cliente
        public void LlenarGrid()
        {
            ClassNegCliente cli = new ClassNegCliente();
            GridViewClientes.DataSource=cli.MuestraCliente();
            GridViewClientes.DataBind();
        }
        #endregion

        #region Guardar Cliente
        public bool GuardarCliente()
        {
            ClassEntCliente cli = new ClassEntCliente();
            cli.Nombre_Cliente = txtNombre.Text;
            cli.Apellido1_Cliente = txtApellido.Text;
            cli.Direccion = txtDireccion.Text;
            cli.N__de_Cedula = txtCedula.Text;
            cli.Telefono_Celular = txtTelefono.Text;
            cli.Estado = chkEstado.Checked;
            cli.ID_Municipio = Convert.ToInt32(DropMunicipio.SelectedValue);
            cli.UserName = txtUser.Text;
            cli.Email = txtmail.Text;


            ClassNegCliente cliGuarda = new ClassNegCliente();
            if (cliGuarda.BuscaClientesDuplicados(cli).Count<1)
            {
                bool resp = cliGuarda.GuardaCliente(cli);
                return resp;
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo guardar', 'error');", true);
                return false;
            }
        }
        #endregion

        #region Limpiar controles
        public void LimpiarControles()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtUser.Text = "";
            txtCedula.Text = "";
            txtmail.Text = "";
        }
        #endregion

        #region Actualizar Cliente
        public bool ActualizaCliente()
        {
            var cli=new ClassEntCliente();
            cli.ID_Cliente = Convert.ToInt32(txtCodigo.Text);
            cli.Nombre_Cliente = txtNombre.Text;
            cli.Apellido1_Cliente = txtApellido.Text;
            cli.Direccion = txtDireccion.Text;
            cli.N__de_Cedula = txtCedula.Text;
            cli.Telefono_Celular = txtTelefono.Text;
            cli.Estado = chkEstado.Checked;
            cli.ID_Municipio = Convert.ToInt32(DropMunicipio.SelectedValue);
            cli.UserName = txtUser.Text;
            cli.Email = txtmail.Text;


            var cliActualiza = new ClassNegCliente();
            bool resp = cliActualiza.ActualizaCliente(cli);
            return resp;
        }
        #endregion

        #region Buscar Cliente
        public void BuscarCliente(string nombre)
        {
            var cli = new ClassNegCliente();
            GridViewClientes.DataSource = cli.MuestraClientexNombre(nombre);
            GridViewClientes.DataBind();
        }
        #endregion

        public void buscaclienteinactivo(string nombre)
        {
            var cli = new ClassNegCliente();
            GVInactivos.DataSource = cli.MuestraClientxNombreInactivos(nombre);
            GVInactivos.DataBind();
        }

        #region Llenar Drop Municipio
        public void LlenarDropMunicipio()
        {
            var cli = new ClassNegMunicipio();
            DropMunicipio.DataSource = cli.MostrarMunicipio();
            DropMunicipio.DataValueField = "ID_Municipio";
            DropMunicipio.DataTextField = "Nombre_Municipio";
            DropMunicipio.DataBind();
        }
        #endregion
        #endregion
        //************************************************//

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDropMunicipio();
                MultiViewCliente.ActiveViewIndex = 0;
                LlenarGrid();
                llenargrirgridbaja();
            }
        }

        //************************************************//
        #region Botones
        #region GuardarCliente
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //GuardarCliente();
            //LimpiarControles();
            MultiViewCliente.ActiveViewIndex = 0;
            if (GuardarCliente())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exito!', 'Cliente Guardado Exitosamente', 'success');", true);
                LlenarGrid();
                txtBuscar.Text = "";
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo guardar, ya Existe', 'error');", true);
            }
            LimpiarControles();
        }
        #endregion

        #region btn Actualizar
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            MultiViewCliente.ActiveViewIndex = 0;
            if (ActualizaCliente())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exito!', 'Cliente Actualizado Exitosamente', 'success');", true);
                LlenarGrid();
                txtBuscar.Text = "";
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo Actualizar', 'error');", true);
            }
            LimpiarControles();
        }
        #endregion

        #region Lista Cliente
        protected void btnLista_Click(object sender, EventArgs e)
        {
            MultiViewCliente.ActiveViewIndex = 0;
            LlenarGrid();
            txtBuscar.Text = "";
        }
        #endregion

        #region btn Buscar
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCliente(txtBuscar.Text);
        }
        #endregion

        #region btn Agregar
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cliente.aspx");
        }
        #endregion
        #endregion

        //************************************************//
        #region Comandos botones de la Grilla
        protected void GridViewClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int indice = row.RowIndex;
            int codigo = Convert.ToInt32(GridViewClientes.DataKeys[indice].Value);

            ClassNegCliente cli = new ClassNegCliente();
            ClassEntCliente cli1 = new ClassEntCliente();
            if (e.CommandName=="cmdEditar")
            {
                cli1 = cli.MuestraClientexID(codigo);
                txtCodigo.Text = cli1.ID_Cliente.ToString();
                txtNombre.Text = cli1.Nombre_Cliente;
                txtApellido.Text = cli1.Apellido1_Cliente;
                txtDireccion.Text = cli1.Direccion;
                txtCedula.Text = cli1.N__de_Cedula;
                txtTelefono.Text = cli1.Telefono_Celular;
                chkEstado.Checked = Convert.ToBoolean(cli1.Estado);
                DropMunicipio.SelectedValue = cli1.ID_Municipio.ToString();
                txtUser.Text = cli1.UserName;
                txtmail.Text = cli1.Email;

                MultiViewCliente.ActiveViewIndex = 1;

                btnGuardar.Enabled = false;
                btnGuardar.Visible = false;

                btnActualizar.Enabled = true;
                btnActualizar.Visible = true;

                btncancelar.Visible = true;
            }
            if (e.CommandName=="cmdEliminar")
            {
                cli.DardeBaja(codigo);
                LlenarGrid();
                llenargrirgridbaja();
                //bool resp = cli.EliminaCliente(codigo);
                //if (resp)
                //{
                //    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Advertencia!', 'Cliente Eliminado', 'warning');", true);
                //    LlenarGrid();
                //}
                //else
                //{
                //    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'Acurrio un problema, no se elimino', 'error');", true);
                //}
            }
        }
        #endregion

        public void llenargrirgridbaja()
        {
            var neg = new ClassNegCliente();
            GVInactivos.DataSource = neg.MuestraClienteInactivos();
            GVInactivos.DataBind();
        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            MultiViewCliente.ActiveViewIndex = 0;
            txtBuscar.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtCedula.Text = "";
            txtTelefono.Text = "";
            txtUser.Text = "";
            txtmail.Text = "";
            btnActualizar.Visible = false;
            btncancelar.Visible = false;
            btnGuardar.Visible = true;
            btnGuardar.Enabled = true;
        }

        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            MultiViewCliente.ActiveViewIndex = 1;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtCedula.Text = "";
            txtTelefono.Text = "";
            txtUser.Text = "";
            txtmail.Text = "";
            btnActualizar.Visible = false;
            btncancelar.Visible = false;
            btnGuardar.Visible = true;
            btnGuardar.Enabled = true;
        }

        protected void GridViewClientes_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewClientes.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropCli");
                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("lblArtoPageOf");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GridViewClientes.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GridViewClientes.PageIndex)
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
                    int currentPage = GridViewClientes.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GridViewClientes.PageCount.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void DropCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewClientes.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropCli");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...           
                GridViewClientes.PageIndex = pageList.SelectedIndex;
                //------------------------------
                LlenarGrid();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        protected void GVInactivos_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GVInactivos.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("dropinactivos");
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

        protected void btnRestaurar_Click(object sender, EventArgs e)
        {

        }

        protected void GVInactivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int indice = row.RowIndex;
            int codigo = Convert.ToInt32(GVInactivos.DataKeys[indice].Value);

            ClassNegCliente cli = new ClassNegCliente();
            ClassEntCliente cli1 = new ClassEntCliente();
            if (e.CommandName=="cmdRestaurar")
            {
                cli.Restaurar(codigo);
                LlenarGrid();
                llenargrirgridbaja();
            }
            if (e.CommandName=="cmdexterminar")
            {
                bool resp = cli.EliminaCliente(codigo);
                if (resp)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Advertencia!', 'Cliente Eliminado', 'warning');", true);
                    llenargrirgridbaja();
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'Acurrio un problema, no se elimino', 'error');", true);
                }
            }
        }

        protected void btnbaja_Click(object sender, EventArgs e)
        {
            MultiViewCliente.ActiveViewIndex = 2;
        }

        protected void btnbuscainactivos_Click(object sender, EventArgs e)
        {
            buscaclienteinactivo(txtbuscainactivos.Text);
        }

        protected void btnactivos_Click(object sender, EventArgs e)
        {
            MultiViewCliente.ActiveViewIndex = 0;
            LlenarGrid();
        }

        protected void btnnew_Click(object sender, EventArgs e)
        {
            MultiViewCliente.ActiveViewIndex = 1;
        }

        protected void dropinactivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GVInactivos.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("dropinactivos");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...           
                GVInactivos.PageIndex = pageList.SelectedIndex;
                //------------------------------
                llenargrirgridbaja();
            }
            catch (Exception)
            {
                //throw;
            }
        }

    }
}