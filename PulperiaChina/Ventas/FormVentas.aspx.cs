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
    public partial class FormVentas : System.Web.UI.Page
    {
        List<ClassEntDetalleTemp> DetalleTemporal = new List<ClassEntDetalleTemp>();

        ClassEntDetalleTemp DetalleTmp = new ClassEntDetalleTemp();


        #region Metodos
        #region Llenar Drop Vendedores
        //public void LlenaVendedor()
        //{
        //    var neg = new ClassNegEmpleado();
        //    DropVendedor.DataSource = neg.MuestraEmpleado();
        //    DropVendedor.DataTextField = "Nombre";
        //    DropVendedor.DataValueField = "IDEmpleado";
        //    DropVendedor.DataBind();
        //}
        #endregion

        #region Llenar Drop Articulos
        public void LlenaArticulos()
        {
            //var neg = new ClassNegArticulo();
            //DropArticulo.DataSource = neg.MuestraArticulo();
            //DropArticulo.DataValueField = "ID_Articulo";
            //DropArticulo.DataValueField = "Nombre_Articulo";
            //DropArticulo.DataBind();
        }
        #endregion

        #region Nº de Factura
        int NumeroDeFactura()
        {
            int noFacto = ClassNegFacturacion.ultimoID();
            return (noFacto + 1);

        }
        #endregion

        //agregado garantia
        #region Muestra Precio y Existencia
        public void CargaDetalleArticulo()
        {
            var neg = new ClassNegArticulo();
            var ent = new ClassEntArticulo();
            foreach (var p in neg.MuestraDetalleBodegaArticulo(Convert.ToInt32(HiddenFieldArticulo.Value),Convert.ToInt32(HiddenFieldBodega.Value)))
            {
                txtprecio.Text = p.Precion_Venta.ToString();
                txtExistencia.Text = p.Existencia.ToString();
                HiddenFieldBodega.Value = p.ID_BodegaArticulo.ToString();
                txtgarantia.Text = p.garantia;
            }
        }
        #endregion

        #region  llenar grid articulo electrodomesticos
        public void Llenargridarticuloelectro(int id)
        {
            var neg=new ClassNegBodegaArticulo();
            GridViewArticuloFactura.DataSource = neg.MuestraBodegaArticuloelectrodomestico(id);
            GridViewArticuloFactura.DataBind();
        }
        #endregion

        #region  llenar grid articulo electrodomesticos
        public void Llenargridarticuloferreteria(int id)
        {
            var neg = new ClassNegBodegaArticulo();
            GridViewFerreteriaFactura.DataSource = neg.MuestraBodegaArticuloferreteria(id);
            GridViewFerreteriaFactura.DataBind();
        }
        #endregion

        //agregado garantia
        #region Guarda Articulo en la tabla Temporal
        public void GuardaArticuloTmp()
        {
            var art = new ClassEntDetalleTemp();
            var neg = new ClassNegFacturacion();

            if (int.Parse(txtExistencia.Text) < int.Parse(txtCantidad.Text))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Advertencia!', 'No hay existencia para la cantidad deseada', 'warning');", true);
                txtCantidad.Text = "";
                txtCantidad.Focus();
            }
            else if (int.Parse(txtCantidad.Text) < 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Advertencia!', 'No se aceptan numeros negativos', 'warning');", true);//info, success, error, warning
                txtCantidad.Text = "";
                txtCantidad.Focus();
            }
            
            else
            {
                art.ID_Articulo = int.Parse(HiddenFieldArticulo.Value);
                art.Precio = int.Parse(txtprecio.Text);
                art.Cantidad = int.Parse(txtCantidad.Text);
                art.Garantia = txtgarantia.Text;
                
                if (CheckDescuento.Checked)
                {
                    art.Descuento = ((int.Parse(txtprecio.Text) * int.Parse(txtCantidad.Text)) * (Convert.ToSingle(DropDescuento.SelectedValue)) / 100);
                }

                else
                {
                    art.Descuento = 0; 
                }

                float sub;
                sub =Convert.ToSingle((int.Parse(txtprecio.Text) * int.Parse(txtCantidad.Text)) - (art.Descuento));
                art.SubTotal = sub;

                int exi = int.Parse(txtExistencia.Text) - int.Parse(txtCantidad.Text);
                txtExistencia.Text = exi.ToString();

                //Se obtiene el nombre de usuario logueado
                art.UserName = HttpContext.Current.User.Identity.Name;

                //Mandar a la capa de datos los valores del detalle
                neg.GuardaTemp(art);
            }
        }
        #endregion

        #region Llenar Grid con los Articulosde la tblVentaTemporal
        public void CargarGridTemp(string user)
        {
            var tmp = new ClassNegFacturacion();

            var articulo = tmp.MuestraTmp(user);

            txttotalventa.Text = articulo.Sum(sub => sub.SubTotal).ToString();
            txtdescapli.Text = string.Format("C$: {0:0.00}", articulo.Sum(sa => sa.Descuento)).ToString();


            foreach (var item in articulo)
            {
                DetalleTemporal.Add(item);
                
            }
            GridViewDetalle.DataSource = DetalleTemporal;
            GridViewDetalle.DataBind();

        }
        #endregion

        #region si existe en la Grid
        int existe(List<ClassEntDetalleTemp> lista, ClassEntDetalleTemp tmp)
        {
            int pos = 0;

            if (lista.Count==0)
            {
                return -1;
            }
            else
            {
                foreach (var item in lista)
                {
                    if (item.ID_Articulo==tmp.ID_Articulo)
                    {
                        return pos;
                    }
                    pos++;
                }
            }
            return -1;
        }
        #endregion

        //agregado garantia
        #region Facturar Articulos
        public bool FacturarArticulo()
        {
            try
            {
                var ent = new ClassEntFacturacion();
                var neg = new ClassNegFacturacion();

                string usuario = HttpContext.Current.User.Identity.Name;

                var u = neg.MuestrausuarioID(usuario);

                ent.Fecha_Vta = DateTime.Now;
                ent.NombreCliente = txtcliente.Text.Trim();
                ent.Anulada = Convert.ToString(false);
                ent.ID_Usuario = u.ID_Usuario;
                ent.Total = Convert.ToDecimal(txttotalventa.Text);
                ent.garantia = txtgarantia.Text.Trim();
                

                neg.Facturar(ent, usuario);

                CargarGridTemp(usuario);

                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }
        #endregion

        public void CargaCambioDolar()
        {
            var neg = new ClassEmpresa();
            foreach (var item in neg.MuestraEmpresaCambio())
            {
                txtCambioDolar.Text = item.CambioDolar.ToString();
            }
            
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenaArticulos();
                txtfecha.Text = DateTime.Now.ToShortDateString();
                txtcodigo.Text = string.Format("{0:FAC000000}", NumeroDeFactura());
                MultiViewFactura.ActiveViewIndex = 0;
                CargaCambioDolar();

                CargarGridTemp(HttpContext.Current.User.Identity.Name);
            }
        }

        protected void DropArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                return;
            }
            GuardaArticuloTmp();
            txtCantidad.Text = "";
            //totalventa.Visible= true;
            txttotalventa.Visible = true;
            //btnFacturar.Visible = true;
            btnCancelar.Visible = true;
            DetalleTmp.UserName = HttpContext.Current.User.Identity.Name;
            CargarGridTemp(HttpContext.Current.User.Identity.Name);
        }

        protected void GridViewDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int indice = row.RowIndex;
            int codigo = Convert.ToInt32(GridViewDetalle.DataKeys[indice].Value);


            var neg = new ClassNegFacturacion();
            if (e.CommandName == "Eliminar")
            {
                bool resp = neg.EliminaDetalle(codigo);
                if (resp)
                {
                    CargarGridTemp(HttpContext.Current.User.Identity.Name);
                }
            }
            if (e.CommandName == "restar")
            {
                int cant = Convert.ToInt32(GridViewDetalle.Rows[indice].Cells[2].Text);
                
                TextBox restar = (TextBox)GridViewDetalle.Rows[indice].FindControl("txtdisminuir");
                int r  = Convert.ToInt32(restar.Text);
                if (Convert.ToInt32(restar.Text) >= cant)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('No se puede disminuir');", true);
                }
                else
                {
                    var tmp = new ClassNegFacturacion();

                    tmp.Cant(r, codigo);

                    CargarGridTemp(HttpContext.Current.User.Identity.Name);
                   // var articulo = tmp.MuestraTmp(HttpContext.Current.User.Identity.Name);
                    //foreach (var item in articulo)
                    //{
                    //    DetalleTemporal.Add(item);
                    
                    //}

                    //DetalleTemporal.FirstOrDefault(x => x.ID_DetalleTemp == (codigo)).Cantidad -= Convert.ToInt32(restar.Text);
                    //DetalleTemporal.FirstOrDefault(x => x.ID_DetalleTemp == (codigo)).SubTotal = DetalleTemporal.FirstOrDefault(x => x.ID_DetalleTemp == (codigo)).precioventa * DetalleTemporal.FirstOrDefault(x => x.ID_DetalleTemp == (codigo)).Cantidad;
                    //DetalleTemporal.FirstOrDefault(x => x.ID_DetalleTemp == (codigo)).SubTotal -= DetalleTemporal.FirstOrDefault(x => x.ID_DetalleTemp == (codigo)).Descuento;

                    //GridViewDetalle.DataSource = DetalleTemporal;
                    //GridViewDetalle.DataBind();
                }
            }
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //Session["HttpContext.Current.User.Identity.Name"]=null;
            //LlenaArticulos();
            var tmp = new ClassNegFacturacion();
            tmp.LimpiarTemp(HttpContext.Current.User.Identity.Name);
            CargarGridTemp(HttpContext.Current.User.Identity.Name);

        }

        protected void btnFacturar_Click(object sender, EventArgs e)
        {
            //FacturarArticulo();

            MultiViewFactura.ActiveViewIndex = 4;

            var tmp = new ClassNegFacturacion();
            var articulo = tmp.MuestraTmp(HttpContext.Current.User.Identity.Name);
            //txttotalpago.Text = articulo.Sum(sub => sub.SubTotal).ToString();
        }

        protected void btnagreararticulofactura_Click(object sender, EventArgs e)
        {
            MultiViewFactura.ActiveViewIndex = 2;
        }

        #region Botones de la VistaBotones

        protected void ImgbtnElectrodomesticos_Click(object sender, ImageClickEventArgs e)
        {
            ClassEntBodegaArticulo ent = new ClassEntBodegaArticulo();
            MultiViewFactura.ActiveViewIndex = 1;
            Llenargridarticuloelectro(ent.ID_Bodega);
        }

        protected void ImgbtnFerrateria_Click(object sender, ImageClickEventArgs e)
        {
            ClassEntBodegaArticulo ent = new ClassEntBodegaArticulo();
            MultiViewFactura.ActiveViewIndex = 3;
            Llenargridarticuloferreteria(ent.ID_Bodega);
        }

        #endregion

        //agregado garantia
        #region Electrodomesticos
        protected void GridViewArticuloFactura_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int indice = row.RowIndex;
                string Codigo = "";
                try
                {
                    Codigo = GridViewArticuloFactura.DataKeys[indice].Value.ToString();
                }
                catch (Exception)
                {

                }
                ClassNegArticulo neg = new ClassNegArticulo();
                if (e.CommandName == "selexionar")
                {
                    var lista = neg.MostrarProductosorID(Convert.ToInt32(Codigo));
                    foreach (var item in lista)
                    {
                        HiddenFieldBodega.Value = (item.IdBodegaArticulo).ToString();
                        HiddenFieldArticulo.Value = item.ID_Articulo.ToString();
                        txtarticulo.Text = item.Nombre_Articulo;
                        txtprecio.Text = (item.Precio_Venta).ToString();
                        txtExistencia.Text = (item.Existencia).ToString();
                        txtgarantia.Text = item.Garantia;
                    }
                    MultiViewFactura.ActiveViewIndex = 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void DropArticuloFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewArticuloFactura.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropArticuloFactura");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...           
                GridViewArticuloFactura.PageIndex = pageList.SelectedIndex;
                //------------------------------
                var ent = new ClassEntBodegaArticulo();
                Llenargridarticuloelectro(ent.ID_Bodega);
            }
            catch (Exception)
            {
                //throw;
            }
        }

        protected void GridViewArticuloFactura_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewArticuloFactura.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropArticuloFactura");
                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("lblfin");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GridViewArticuloFactura.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GridViewArticuloFactura.PageIndex)
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
                    int currentPage = GridViewArticuloFactura.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GridViewArticuloFactura.PageCount.ToString();
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        //agregado garantia
        #region Ferreteria
        protected void GridViewFerreteriaFactura_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int indice = row.RowIndex;
                string Codigo = "";
                try
                {
                    Codigo = GridViewFerreteriaFactura.DataKeys[indice].Value.ToString();
                }
                catch (Exception)
                {

                }
                ClassNegArticulo neg = new ClassNegArticulo();
                if (e.CommandName == "selec")
                {
                    var lista = neg.MostrarProductosorID(Convert.ToInt32(Codigo));
                    foreach (var item in lista)
                    {
                        HiddenFieldBodega.Value = (item.IdBodegaArticulo).ToString();
                        HiddenFieldArticulo.Value = item.ID_Articulo.ToString();
                        txtarticulo.Text = item.Nombre_Articulo;
                        txtprecio.Text = (item.Precio_Venta).ToString();
                        txtExistencia.Text = (item.Existencia).ToString();
                        txtgarantia.Text = item.Garantia;
                    }
                    MultiViewFactura.ActiveViewIndex = 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void GridViewFerreteriaFactura_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewFerreteriaFactura.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("Dropferret");
                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("lblfin");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GridViewFerreteriaFactura.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GridViewFerreteriaFactura.PageIndex)
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
                    int currentPage = GridViewFerreteriaFactura.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GridViewFerreteriaFactura.PageCount.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void Dropferret_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewFerreteriaFactura.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("Dropferret");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...           
                GridViewFerreteriaFactura.PageIndex = pageList.SelectedIndex;
                //------------------------------
                var ent = new ClassEntBodegaArticulo();
                Llenargridarticuloferreteria(ent.ID_Bodega);
            }
            catch (Exception)
            {
                //throw;
            }
        }

        #endregion

        #region Metodoo Pagar

        public bool Pagar()
        {
            double pago = 0;
            double Total = 0;
            double Cambio = 0;
            double TotalPagado = 0;


            Total = Convert.ToDouble(txttotalventa.Text);

            if (txtdolarrecibido.Text == "" && txtcordobasrecibido.Text == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Usted no ha Pagado..?  por favor Pague');", true);
                lblAlert.Text = "";
                txtcordobasrecibido.Focus();
                return false;
            }
            if (txtdolarrecibido.Text != "")
            {
                Cambio = (Convert.ToDouble(txtdolarrecibido.Text) * Convert.ToDouble(txtCambioDolar.Text));
                txtrecibidototal.Text = Convert.ToString(lblconversion.Text);
                pago += Cambio;
                lblconversion.Text = string.Format("Valor del Cambio C$: {0:0.00}", Cambio).ToString();
            }
            if (txtcordobasrecibido.Text != "")
            {
                pago += Convert.ToDouble(txtcordobasrecibido.Text);
            }
            txtrecibidototal.Text = pago.ToString();


            if (Total > pago)
            {
                lblAlert.Text = string.Format("El pago es menor que el total,  le Faltan C$: {0:0.00}, Cordobas", (Total - pago));
                txtVuelto.Text = "";
                return false;
            }
            //TxtVuelto.Text = string.Format("C$ {0:0.00}", (pago - Total));
            TotalPagado = (pago - Total);
            txtVuelto.Text = string.Format("C$: {0:0.00}", TotalPagado).ToString();
            lblAlert.Text = "";
            return true;
        }
        #endregion

        #region Calcula vuelto dolares
        public void Calculavueltodolar()
        {
            var neg = new ClassEntFacturacion();

            float tasa;
            float conversion;
            

            neg.Dolar = Convert.ToDecimal(txtdolarrecibido.Text);
            tasa = Convert.ToSingle(txtCambioDolar.Text);
            conversion = Convert.ToSingle(txtdolarrecibido.Text) * Convert.ToSingle(txtCambioDolar.Text);
            txtVuelto.Text = (conversion - Convert.ToInt32(txttotalventa.Text)).ToString();
        }
        #endregion

        #region Calcula vuelto dolares
        public void calaculavueltocordoba()
        {
            txtVuelto.Text = (int.Parse(txtdolarrecibido.Text) - int.Parse(txttotalventa.Text)).ToString();
        }
        #endregion

        protected void btnverfactura_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Ventas/VentasRealizadas.aspx");
        }

        protected void btnRealizarfactura_Click(object sender, EventArgs e)
        {
                FacturarArticulo();
                txtcliente.Text = "";
                txtarticulo.Text = "";
                HiddenFieldArticulo.Value = null;
                txtprecio.Text = "";
                txtExistencia.Text = "";
                txttotalventa.Text = "";
                txtgarantia.Text = "";
                txtCambioDolar.Text = "";
                txtdescapli.Text = "";
                txtdolarrecibido.Text = "";
                txtcordobasrecibido.Text = "";
                txtrecibidototal.Text = "";
                txtVuelto.Text = "";
                lblAlert.Text = "";
                lblconversion.Text = "";
                Response.Redirect("/Reportes/últimaFacturar.aspx");
        }

        protected void txtdolarrecibido_TextChanged(object sender, EventArgs e)
        {
            Session["pago"] = Pagar();
        }

        protected void txtcordobasrecibido_TextChanged(object sender, EventArgs e)
        {
            Session["pago"] = Pagar();
        }

        protected void CBDolar_CheckedChanged(object sender, EventArgs e)
        {
            if (true)
            {
                txtCambioDolar.Enabled = true;
                txtdolarrecibido.Enabled = true;
            }
            else
            {
            //    txtCambioDolar.Enabled = false;
            //    txtdolarrecibido.Enabled = false;
            }
        }

        protected void GridViewDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType==DataControlRowType.DataRow)
                {
                    string cantidad = e.Row.Cells[2].Text;
                    TextBox txt = (TextBox)e.Row.FindControl("txtdisminuir");
                    Button btn = (Button)e.Row.FindControl("btndisminuir");

                    if (Convert.ToInt32(cantidad)==1)
                    {
                        btn.Enabled = false; 
                        txt.Enabled = false;
                        e.Row.ToolTip = "No se puede disminuir la cantidad de este Artículo";
                    }
                    else
                    {
                        btn.Enabled = true;
                        txt.Enabled = true;
                        e.Row.ToolTip = "";
                    }
                }
            }
            catch (Exception)
            {
                
               
            }
        }
    }
}