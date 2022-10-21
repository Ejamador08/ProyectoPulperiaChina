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
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        public void DetalleArticulos(int id)
        {
            //var neg = new ClassNegArticulo();
            //var x = neg.MuestraDetalleArtxID(ID);
            var ent = new ClassEntArticulo();
            var neg = new ClassNegArticulo();

            ent = neg.EncuentraUnArticulo(id);

            ImageArticulo.ImageUrl = "../" + ent.RutaImagen;
            lblCodigo.Text = ent.ID_Articulo.ToString();
            lblNombre.Text = ent.Nombre_Articulo;
            //lblPrecio.Text = ent.Precio.ToString();
            Descripcion.Text = ent.Descripcion.ToString();
            //lblCategoria.Text = ent.ID_Categoria.ToString();

            //MuestraArticRelacionados(x.ID_Articulo, x.ID_Categoria);

            //Page.Title = "Articulo" + x.Nombre_Articulo;
        }

        #region Muestra Articulos Relacionados
        //public void MuestraArticRelacionados(int id, int? cat)
        //{
        //    var neg = new ClassNegArticulo();
        //    ListViewRelacionados.DataSource = neg.MostrarArticRel(id, cat);
        //    ListViewRelacionados.DataBind();
        //}
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string Valor = RouteData.Values["ID"].ToString();
                //if (Valor != null)
                //{
                //    DetalleArticulos(Convert.ToInt32(Valor));
                //}
                //estafunciona conel otro metodo que esta comentariado
                int Valor = Convert.ToInt32(Request.QueryString["ID"]);
                DetalleArticulos(Valor);
            }
        }
    }
}