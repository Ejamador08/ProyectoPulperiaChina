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
    public partial class Bodegas_Articulos : System.Web.UI.Page
    {

        #region Metodos
        #region Llena Grid Bodega-Articulos
        public void LlenarGrid()
        {
            var neg = new ClassNegBodegaArticulo();
            GridViewBodegaArticulo.DataSource = neg.MuestraBodegaArticulo();
            GridViewBodegaArticulo.DataBind();
        }
        #endregion
        #region Llenar Grid Articulos
        public void LlenaGridArticulos()
        {
            var neg = new ClassNegArticulo();
            GridArticulos.DataSource = neg.MuestraBA();
            GridArticulos.DataBind();
        }
        #endregion
        #region Llenar Grid Bodegas
        public void LlenaGridBodegas()
        {
            var neg = new ClassNegBodega();
            GridBodega.DataSource = neg.MuestraBodega();
            GridBodega.DataBind();
        }
        #endregion
        #region Llenar Drop Articulo
        //public void LlenaDropArticulo()
        //{
        //    var neg = new ClassNegArticulo();
        //    DropArticulo.DataSource = neg.MuestraArticulo();
        //    DropArticulo.DataValueField = "ID_Articulo";
        //    DropArticulo.DataTextField = "Nombre_Articulo";
        //    DropArticulo.DataBind();
        //}
        #endregion
        #region Llenar Drop Bodega
        //public void LlenaDropBodega()
        //{
        //    var neg = new ClassNegBodega();
        //    DropBodega.DataSource = neg.MuestraBodega();
        //    DropBodega.DataValueField = "ID_Bodega";
        //    DropBodega.DataTextField = "Nombre_Bodega";
        //    DropBodega.DataBind();
        //}
        #endregion
        #region Guarda Bodega-Articulos
        public bool GuardaBA()
        {
            var ent = new ClassEntBodegaArticulo();
            ent.ID_Articulo = Convert.ToInt32(Hiddenarticulo.Value);
            ent.ID_Bodega=Convert.ToInt32(HiddenBodega.Value);
            ent.Precio_Compra = Convert.ToSingle(0);
            ent.Precion_Venta = Convert.ToSingle(0);
            ent.Existencia = Convert.ToInt32(0);
            ent.UserName = HttpContext.Current.User.Identity.Name;
            
            var neg = new ClassNegBodegaArticulo();
            if (neg.Duplicados(ent).Count<1)
            {
                bool resp = neg.GuardaBodegaArticulo(ent);
                return resp;
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo guardar', 'error');", true);
                return false;
            }
        }
        #endregion
        #region Actualiza Bodega-Articulo
        public bool ActualizaBA()
        {
            var ent = new ClassEntBodegaArticulo();
            ent.ID_Articulo = Convert.ToInt32(Hiddenarticulo.Value);
            ent.ID_Bodega = Convert.ToInt32(HiddenBodega.Value);
            ent.Precio_Compra = Convert.ToSingle(txtcompra.Text);
            ent.Precion_Venta = Convert.ToSingle(txtventa.Text);
            ent.Existencia = Convert.ToInt32(txtexistencia.Text);
            ent.UserName = HttpContext.Current.User.Identity.Name;

            var neg = new ClassNegBodegaArticulo();
            bool resp= neg.ActualizaBodegaArticulo(ent);
            return resp;
        }
        #endregion
        #region Llimpiar Controles
        public void LimpiarControles()
        {
            txtart.Text = "";
            txtbod.Text = "";
            txtcompra.Text = "";
            txtventa.Text = "";
            txtexistencia.Text = "";
        }
        #endregion
        #region Llenar Grid Busca x Nombre
        public void BuscaBAxNombre(string name)
        {
            ClassNegBodegaArticulo neg = new ClassNegBodegaArticulo();
            GridViewBodegaArticulo.DataSource = neg.MuestraBodegaArticuloxNombre(name);
            GridViewBodegaArticulo.DataBind();
        }
        #endregion
        #region Llenar Grid Buscar x Nombre Articulos
        public void BuscaXNombreArticulos(string name)
        {
            ClassNegArticulo neg = new ClassNegArticulo();
            GridArticulos.DataSource = neg.MostrarArticulosxNombreBA(name);
            GridArticulos.DataBind();
        }
        #endregion
        #region Llenar Grid Buscar x Nombre Bodegas
        public void BuscaXNombreBodegas(string name)
        {
            ClassNegBodega neg = new ClassNegBodega();
            GridBodega.DataSource = neg.MuestraBodegaxNombre(name);
            GridBodega.DataBind();
        }
        #endregion
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                LlenaGridArticulos();
                LlenaGridBodegas();
                //LlenaDropArticulo();
                //LlenaDropBodega();
                MultiViewBodegaArticulo.ActiveViewIndex = 0;
            }
        }

        #region Botones
        protected void btnLista_Click(object sender, EventArgs e)
        {
            MultiViewBodegaArticulo.ActiveViewIndex = 0;
            LlenarGrid();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            MultiViewBodegaArticulo.ActiveViewIndex = 0;
            if (GuardaBA())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exito!', 'Articulo Guardado Exitosamente', 'success');", true);
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo guardar, ya Existe', 'error');", true);
            }
            LlenarGrid();
            txtbuscar.Text = "";
            LimpiarControles();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            MultiViewBodegaArticulo.ActiveViewIndex = 0;
            if (ActualizaBA())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exito!', 'Articulo Actualizado Exitosamente', 'success');", true);
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo Actualizar', 'error');", true);
            }
            LlenarGrid();
            txtbuscar.Text = "";
            LimpiarControles();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            MultiViewBodegaArticulo.ActiveViewIndex = 0;
            BuscaBAxNombre(txtbuscar.Text);
            LlenarGrid();
        }
        #endregion

        #region Comandos En La Grilla
        #region Grid Bodega Articulos
        protected void GridViewBodegaArticulo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int indice = row.RowIndex;
            int codigo = Convert.ToInt32(GridViewBodegaArticulo.DataKeys[indice].Value);

            var neg = new ClassNegBodegaArticulo();
            var ent = new ClassEntBodegaArticulo();
            if (e.CommandName=="cmdeditar")
            {
                ent = neg.MuestraBodegaArticuloxID(codigo);
                txtcodigo.Text = ent.ID_BodegaArticulo.ToString();
                //DropArticulo.SelectedValue = ent.ID_Articulo.ToString();
                //DropBodega.SelectedValue = ent.ID_Bodega.ToString();
                Hiddenarticulo.Value = ent.ID_Articulo.ToString();
                HiddenBodega.Value = ent.ID_Bodega.ToString();
                txtcompra.Text = ent.Precio_Compra.ToString();
                txtventa.Text = ent.Precion_Venta.ToString();
                txtexistencia.Text = ent.Existencia.ToString();

                MultiViewBodegaArticulo.ActiveViewIndex = 1;

                btnGuardar.Visible = false;

                btnActualizar.Visible = true;
                btnActualizar.Enabled = true;

                btncancactu.Visible = true;
            }
            if (e.CommandName=="cmdeliminar")
            {
                bool resp = neg.EliminaBodegaArticulo(codigo);
                if (resp)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Advertencia!', 'Articulo Eliminado de Bodega', 'warning');", true);
                    LlenarGrid();
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'Acurrio un problea, no se elimino', 'error');", true);
                }
            }
        }

        protected void GridViewBodegaArticulo_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewBodegaArticulo.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("Dropbodeart");
                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("lblborart");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GridViewBodegaArticulo.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GridViewBodegaArticulo.PageIndex)
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
                    int currentPage = GridViewBodegaArticulo.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GridViewBodegaArticulo.PageCount.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void Dropbodeart_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewBodegaArticulo.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("Dropbodeart");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...           
                GridViewBodegaArticulo.PageIndex = pageList.SelectedIndex;
                //------------------------------
                LlenarGrid();
            }
            catch (Exception)
            {
                //throw;
            }

        }
        #endregion

        #region Grid Articulo
        protected void btnbuscarart_Click(object sender, EventArgs e)
        {
            BuscaXNombreArticulos(txtbuscaart.Text);
            txtbuscaart.Text = "";
        }

        protected void btncargaart_Click(object sender, EventArgs e)
        {
            MultiViewBodegaArticulo.ActiveViewIndex = 2;
            LlenaGridArticulos();
        }

        protected void GridArticulos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int indice = row.RowIndex;
                string Codigo = "";
                try
                {
                    Codigo = GridArticulos.DataKeys[indice].Value.ToString();
                }
                catch (Exception)
                {

                }
                ClassNegArticulo neg = new ClassNegArticulo();
                if (e.CommandName == "seleccionar")
                {
                    var lista = neg.MuestraBaedicion(Convert.ToInt32(Codigo));
                    foreach (var p in lista)
                    {
                        Hiddenarticulo.Value = p.ID_Articulo.ToString();
                        txtart.Text = p.Nombre_Articulo;
                    }
                    MultiViewBodegaArticulo.ActiveViewIndex = 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GridArticulos_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridArticulos.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("Droparticulos");
                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("lblfin");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GridArticulos.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GridArticulos.PageIndex)
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
                    int currentPage = GridArticulos.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GridArticulos.PageCount.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void Droparticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridArticulos.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("Droparticulos");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...           
                GridArticulos.PageIndex = pageList.SelectedIndex;
                //------------------------------
                LlenaGridArticulos();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            MultiViewBodegaArticulo.ActiveViewIndex = 0;
            LimpiarControles();
        }
        #endregion

        #region Grid Bodega
        protected void btncargabid_Click(object sender, EventArgs e)
        {
            MultiViewBodegaArticulo.ActiveViewIndex = 3;
            LlenaGridBodegas();
        }

        protected void btnbuscabod_Click(object sender, EventArgs e)
        {
            BuscaXNombreBodegas(txtbodega.Text);
            txtbodega.Text = "";
        }

        protected void GridBodega_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int indice = row.RowIndex;
                string Codigo = "";
                try
                {
                    Codigo = GridBodega.DataKeys[indice].Value.ToString();
                }
                catch (Exception)
                {

                }
                ClassNegBodega neg = new ClassNegBodega();
                if (e.CommandName=="seleccionar")
                {
                    var lista=neg.MostrarProductosorID(Convert.ToInt32(Codigo));
                    foreach (var p in lista)
                    {
                        HiddenBodega.Value = p.ID_Bodega.ToString();
                        txtbod.Text = p.Nombre_Bodega;
                    }
                    MultiViewBodegaArticulo.ActiveViewIndex = 1;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void GridBodega_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridBodega.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropBodegas");
                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("lblfinal");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GridBodega.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GridBodega.PageIndex)
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
                    int currentPage = GridBodega.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GridBodega.PageCount.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void DropBodegas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridBodega.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropBodegas");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...           
                GridBodega.PageIndex = pageList.SelectedIndex;
                //------------------------------
                LlenaGridBodegas();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            MultiViewBodegaArticulo.ActiveViewIndex = 0;
            LimpiarControles();
        }
        #endregion

        protected void btncancactu_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            MultiViewBodegaArticulo.ActiveViewIndex = 0;
            txtbuscar.Text = "";
        }

        #endregion

        protected void btnagregarnuevo_Click(object sender, EventArgs e)
        {
            MultiViewBodegaArticulo.ActiveViewIndex = 1;
            txtart.Text = "";
            txtbod.Text = "";
        }

        
    }
}