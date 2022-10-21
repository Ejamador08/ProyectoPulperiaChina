using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;

namespace PulperiaChina.Ventas
{
    public partial class FormCompra : System.Web.UI.Page
    {
        /// <summary>
        /// muestra el numero de faltura con el siguiente formato...
        /// FAC000001... seria la factura #1
        /// </summary>
        /// <returns></returns>
        #region Nº de Factura
        int NumeroDeFactura()
        {
            var neg = new ClassNegCompra();
            int noFacto = neg.ultimoID();
            return (noFacto + 1);

        }
        #endregion

        //public void LlenarGridProveedor()
        //{
        //    var neg = new ClassNegProveedor();
        //    GvProveedor.DataSource = neg.MuestraProveedor();
        //    GvProveedor.DataBind();
        //}

        public void LlenarGridLN()
        {
            var neg = new ClassNegArticulo();
            GvlineaBlanca.DataSource = neg.Mostrarcompra();
            GvlineaBlanca.DataBind();
        }

        //public void LlenarGridMueble(int id)
        //{
        //    var neg = new ClassNegArticulo();
        //    GvMuebles.DataSource = neg.ArticuloMueble(id);
        //    GvMuebles.DataBind();
        //}

        //public void LlenarGridConstruxion(int id)
        //{
        //    var neg = new ClassNegArticulo();
        //    GvContruccion.DataSource = neg.ArticuloConstruxion(id);
        //    GvContruccion.DataBind();
        //}

        //public void LlenarDropBodega()
        //{
        //    var neg = new ClassNegBodega();
        //    DropBodega.DataSource=neg.MuestraBodega();
        //    DropBodega.DataValueField = "ID_Bodega";
        //    DropBodega.DataTextField = "Nombre_Bodega";
        //    DropBodega.DataBind();
        //}

        //public void LlenarDropMarca()
        //{
        //    var neg = new ClassNegMarca();
        //    DropMarca.DataSource=neg.MuestraMarca();
        //    DropMarca.DataValueField = "IDMarca";
        //    DropMarca.DataTextField = "Nombre_Marca";
        //    DropMarca.DataBind();
        //}

        public void CargaGridTemp(string user)
        {
            var neg = new ClassNegCompra();

            var articulo = neg.MuestraTmp(user);

            //string.Format("C$: {0:0.00}", )
            txttotal.Text = articulo.Sum(sub => sub.SubTotal).ToString();

            GvDetalleCompra.DataSource = articulo;
            GvDetalleCompra.DataBind();
        }

        #region Guarda Articulo en la tabla Temporal
        public void GuardTemp()
        {
            var ent = new ClassEntDetalleComp();
            var neg = new ClassNegCompra();


            if (txtarticulo.Text=="")
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Advertencia!', 'aun no hay articulo selelccionado', 'warning');", true);//info, success, error, warning
            }
            else
            {
                ent.ID_Articulo = Convert.ToInt32(HdArticulo.Value);
                ent.Precio_Compra = Convert.ToDecimal(txtprecio.Text);
                ent.Precio_Venta = Convert.ToDecimal(Convert.ToDecimal(txtprecio.Text) * Convert.ToDecimal(1.05));
                ent.Cantidad = Convert.ToInt32(txtcantidad.Text);
                ent.ID_Proveedor = Convert.ToInt32(Hdproveedor.Value);
                ent.ID_Bodega = Convert.ToInt32(Hdbodega.Value);
                ent.ID_Marca = Convert.ToInt32(Hdmarca.Value);
                ent.Fecha_Entrega = DateTime.Now;
                ent.UserName = HttpContext.Current.User.Identity.Name;
                ent.SubTotal = Convert.ToInt32(txtcantidad.Text) * Convert.ToInt32(txtprecio.Text);

                neg.GuardaTemp(ent);
            }
        }
        #endregion

        public bool IngresarArticulo()
        {
            try
            {
                var ent = new ClassEntCompra();
                var neg = new ClassNegCompra();

                string usuario = HttpContext.Current.User.Identity.Name;

                //var u = neg.MuestrausuarioID(usuario);

                ent.Fecha_Compra = DateTime.Now;
                ent.Total = Convert.ToDecimal(txttotal.Text);

                neg.Comprar(ent, usuario);

                CargaGridTemp(usuario);
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //LlenarDropBodega();
                //LlenarDropMarca();
                txtfecha.Text = DateTime.Now.ToLongDateString();
                txtnumfac.Text = string.Format("{0:FAC000000}", NumeroDeFactura());
                MVCompra.ActiveViewIndex = 0;

                CargaGridTemp(HttpContext.Current.User.Identity.Name);
            }
        }

        //protected void btnprov_Click(object sender, EventArgs e)
        //{
        //    MVCompra.ActiveViewIndex = 4;
        //    LlenarGridProveedor();
        //}

        protected void btnart_Click(object sender, EventArgs e)
        {
            MVCompra.ActiveViewIndex = 1;
            LlenarGridLN();
        }

        protected void GvDetalleCompra_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int indice = row.RowIndex;
            int codigo = Convert.ToInt32(GvDetalleCompra.DataKeys[indice].Value);

            var neg = new ClassNegCompra();
            if (e.CommandName == "eliminar")
            {
                bool resp = neg.EliminaTemp(codigo);
                if (resp)
                {
                    CargaGridTemp(HttpContext.Current.User.Identity.Name);
                }
            }
        }

        protected void btnAtraBotones_Click(object sender, EventArgs e)
        {
            MVCompra.ActiveViewIndex = 0;
            txtarticulo.Text = "";
            txtprecio.Text = "";
            txtcantidad.Text = "";
            HdArticulo.Value = null;
        }

        //multivista Botones
        protected void ImgbtnFerrateria_Click(object sender, ImageClickEventArgs e)
        {
            //ClassEntArticulo neg = new ClassEntArticulo();
            //MVCompra.ActiveViewIndex=2;
            //LlenarGridLN(neg.ID_Categoria);
        }

        protected void ImgbtnElectrodomesticos_Click(object sender, ImageClickEventArgs e)
        {
            //ClassEntArticulo neg = new ClassEntArticulo();
            //MVCompra.ActiveViewIndex = 3;
            //LlenarGridMueble(neg.ID_Categoria);
        }

        protected void imgmat_Click(object sender, ImageClickEventArgs e)
        {
            //ClassEntArticulo neg = new ClassEntArticulo();
            //MVCompra.ActiveViewIndex = 4;
            //LlenarGridConstruxion(neg.ID_Categoria);
        }
        //multivista Botones--FIN 

        //ROwCommand Proveedo
        //protected void GvProveedor_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
        //        int indice = row.RowIndex;
        //        string Codigo = "";
        //        try
        //        {
        //            Codigo = GvProveedor.DataKeys[indice].Value.ToString();
        //        }
        //        catch (Exception)
        //        {

        //        }
        //        var neg = new ClassNegProveedor();
        //        if (e.CommandName == "esteprov")
        //        {
        //            var lista = neg.MostrarProvsorID(Convert.ToInt32(Codigo));
        //            foreach (var item in lista)
        //            {
        //                //Hdproveedor.Value = item.ID_Proveedor.ToString();
        //                txtproveedor.Text = item.Nombre_Proveedor;
        //            }
        //            MVCompra.ActiveViewIndex = 0;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //ROwCommand Proveedo--FIN

        //RowCommand de las grillas de los articulos

        protected void GvlineaBlanca_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int indice = row.RowIndex;
                string codigo = "";
                try
                {
                    codigo = GvlineaBlanca.DataKeys[indice].Value.ToString();
                }
                catch (Exception)
                {

                }
                var neg = new ClassNegArticulo();
                if (e.CommandName == "estelinea")
                {
                    var lista = neg.MostrarLineaBlanca(Convert.ToInt32(codigo));
                    foreach (var item in lista)
                    {
                        Hdproveedor.Value = item.ID_Categoria.ToString();
                        Hdbodega.Value = item.ID_Bodega.ToString();
                        Hdmarca.Value = item.ID_Marca.ToString();
                        HdArticulo.Value = item.ID_Articulo.ToString();
                        txtarticulo.Text = item.Nombre_Articulo;
                        txtproveedor.Text = item.NombreProveedor;
                        txtbodega.Text = item.NombreBodega;
                        txtmarca.Text = item.NombreMarca;
                        txtprecio.Text = Convert.ToString(item.Precio_Venta);
                        txtcantidad.Text = Convert.ToString(item.Existencia);
                    }
                    MVCompra.ActiveViewIndex = 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GvMuebles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        //    try
        //    {
        //        GridViewRow linea = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
        //        int indice = linea.RowIndex;
        //        string codigo = "";
        //        try
        //        {
        //            codigo = GvMuebles.DataKeys[indice].Value.ToString();
        //        }
        //        catch (Exception)
        //        {

        //        }
        //        var neg = new ClassNegArticulo();
        //        if (e.CommandName == "mueble")
        //        {
        //            var lista = neg.MostrarMueble(Convert.ToInt32(codigo));
        //            foreach (var item in lista)
        //            {
        //                HdCatgoria.Value = (item.ID_Categoria).ToString();
        //                HdArticulo.Value = (item.ID_Articulo).ToString();
        //                txtarticulo.Text = item.Nombre_Articulo;
        //                txtproveedor.Text = item.NombreProveedor;
        //                txtcantidad.Text = (item.Existencia).ToString();
        //                txtprecio.Text = (item.Precio_Venta).ToString();
        //                txtbodega.Text = item.NombreBodega;
        //                txtmarca.Text = item.NombreMarca;
        //            }
        //            MVCompra.ActiveViewIndex = 0;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }


        }

        protected void GvContruccion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //try
            //{
            //    GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            //    int indice = row.RowIndex;
            //    string cont = "";
            //    try
            //    {
            //        cont = GvContruccion.DataKeys[indice].Value.ToString();
            //    }
            //    catch (Exception)
            //    {

            //    }
            //    var neg = new ClassNegArticulo();
            //    if (e.CommandName == "extecontr")
            //    {
            //        var lista = neg.Mostrarcontruccion(Convert.ToInt32(cont));//Convert.ToInt32(cont)
            //        foreach (var item in lista)
            //        {
            //            HdCatgoria.Value = item.ID_Categoria.ToString();
            //            HdArticulo.Value = item.ID_Articulo.ToString();
            //            txtarticulo.Text = item.Nombre_Articulo;
            //            txtproveedor.Text = item.NombreProveedor;
            //            txtbodega.Text = item.NombreBodega;
            //            txtmarca.Text = item.NombreMarca;
            //            txtprecio.Text = Convert.ToString(item.Precio_Venta);
            //            txtcantidad.Text = Convert.ToString(item.Existencia);
            //        }
            //        MVCompra.ActiveViewIndex = 0;
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        protected void btnatrasln_Click(object sender, EventArgs e)
        {
            MVCompra.ActiveViewIndex = 0;
            txtproveedor.Text = "";
            txtarticulo.Text = "";
            txtprecio.Text = "";
            txtcantidad.Text = "";
            txtbodega.Text = "";
            txtmarca.Text = "";
        }

        protected void btnatraselec_Click(object sender, EventArgs e)
        {
            //MVCompra.ActiveViewIndex = 1;
        }

        protected void btnatrascon_Click(object sender, EventArgs e)
        {
            //MVCompra.ActiveViewIndex = 1;
        }

        protected void btnnuevoart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Visitantes/Articulos.aspx");
        }

        protected void DropArto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GvlineaBlanca.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropArto");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...           
                GvlineaBlanca.PageIndex = pageList.SelectedIndex;
                //------------------------------
                LlenarGridLN();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        protected void GvlineaBlanca_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GvlineaBlanca.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropArto");
                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("lblArtoPageOf");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GvlineaBlanca.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GvlineaBlanca.PageIndex)
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
                    int currentPage = GvlineaBlanca.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GvlineaBlanca.PageCount.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtarticulo.Text=="")
            {
                return;
            }
            GuardTemp();
            CargaGridTemp(HttpContext.Current.User.Identity.Name);
        }

        protected void btningresar_Click(object sender, EventArgs e)
        {
            IngresarArticulo();
            txtproveedor.Text = "";
            Hdproveedor.Value = null;
            txtarticulo.Text = "";
            HdArticulo.Value = null;
            txtcantidad.Text = "";
            txtprecio.Text = "";
            txtbodega.Text = "";
            txtmarca.Text = "";
        }



        //protected void btnagregarprov_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/Visitantes/Proveedor.aspx");
        //}
        //RowCommand de las grillas de los articulos---FIN



    }
}