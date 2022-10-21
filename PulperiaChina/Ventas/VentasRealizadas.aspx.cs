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
    public partial class VentasRealizadas : System.Web.UI.Page
    {
        public void MuestraFacturas()
        {
            var neg = new ClassNegFacturacion();
            GvFactura.DataSource = neg.MuestraFactura();
            GvFactura.DataBind();
        }

        public void BuscarFacturaxNombreCliente(string name)
        {
            var neg = new ClassNegFacturacion();
            GvFactura.DataSource = neg.BuscaFacturaxNombreCliente(name);
            GvFactura.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MvVentas.ActiveViewIndex = 0;
                MuestraFacturas();
            }
        }

        protected void btnirfactura_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Ventas/FormVentas.aspx");
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            BuscarFacturaxNombreCliente(txtbuscar.Text);
        }

        protected void GvFactura_DataBound1(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GvFactura.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropArto");
                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("lblArtoPageOf");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GvFactura.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GvFactura.PageIndex)
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
                    int currentPage = GvFactura.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GvFactura.PageCount.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void GvFactura_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                int indice = row.RowIndex;
                int codigo = Convert.ToInt32(GvFactura.DataKeys[indice].Value.ToString());

                ClassNegFacturacion neg = new ClassNegFacturacion();
                if (e.CommandName=="detalle")
                {
                    GvDetalle.DataSource = neg.muestradetalleFacturaGrid(codigo);
                    GvDetalle.DataBind();
                }
                MvVentas.ActiveViewIndex = 1;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void DropArto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GvFactura.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropArto");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...           
                GvFactura.PageIndex = pageList.SelectedIndex;
                //------------------------------
                MuestraFacturas();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        protected void btndetRegresar_Click(object sender, EventArgs e)
        {
            MvVentas.ActiveViewIndex = 0;
        }

        protected void btnFacturanueva_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Ventas/FormVentas.aspx");
        }
    }
}