using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaNegocio;
using CapaEntidad;
using System.IO;


namespace PulperiaChina.Visitantes
{
    public partial class Articulos : System.Web.UI.Page
    {
        #region Metodos
        #region Mostrar Articulos x Nombre referencia al btn Buscar
        public void BuscaProductoxNombre(string nombre)
        {
            ClassNegArticulo artic = new ClassNegArticulo();
            GridViewArticulo.DataSource = artic.MostrarArticulosxNombre(nombre);
            GridViewArticulo.DataBind();
        }
        #endregion

        public void BuscaXNombreInactivos(string nombre)
        {
            var neg = new ClassNegArticulo();
            GvInactivos.DataSource = neg.MostrarArticulosxNombreInactivos(nombre);
            GvInactivos.DataBind();
        }

        #region LlenarDropcategoria
        public void LlenarDropCategoria()
        {
            var cat = new ClassNegCategoria();
            DropCategoria.DataSource = cat.MuestraCategoria();
            DropCategoria.DataValueField = "ID_Categoria";
            DropCategoria.DataTextField = "Nombre_Categoria";
            DropCategoria.DataBind();
        }
        #endregion

        #region LlenarDropProveedor
        public void LlenarDropProveedor()
        {
            var cat = new ClassNegProveedor();
            DropProveedor.DataSource = cat.MuestraProveedor();
            DropProveedor.DataValueField = "ID_Proveedor";
            DropProveedor.DataTextField = "Nombre_Proveedor";
            DropProveedor.DataBind();
        }
        #endregion

        #region LlenarDropMarca
        public void LlenarDropMarca()
        {
            var neg = new ClassNegMarca();
            DropMarca.DataSource = neg.MuestraMarca();
            DropMarca.DataValueField = "IDMarca";
            DropMarca.DataTextField = "Nombre_Marca";
            DropMarca.DataBind();

        }
        #endregion

        #region  Llena Grid Articulo con Nombre referencia al btn Ir Lista
        public void LlenarGrid()
        {
            var grid = new ClassNegArticulo();
            GridViewArticulo.DataSource = grid.MuestraArticulo();
            GridViewArticulo.DataBind();
        }
        #endregion

        public void llenargridinactivos()
        {
            var neg = new ClassNegArticulo();
            GvInactivos.DataSource = neg.MostrarArticuloInactivos();
            GvInactivos.DataBind();
        }

        #region Guardar Imagen en el servidor y retorna la ruta para la base de datos
        public string RutaImage()
        {
            bool fileOk = false;
            string respuesta = "";
            string ruta = Server.MapPath("~/Imagenes/ImagenesArticulos/");

            try
            {
                if (FileUploadArticulo.HasFile)//Si tiene archivo seleccionado
                {
                    string extension = Path.GetExtension(FileUploadArticulo.FileName).ToLower();
                    string[] extensionValida = { ".jpg", ".png", ".gif", ".jpeg" };
                    for (int i = 0; i < extensionValida.Length; i++)
                    {

                        if (extension == extensionValida[i])
                        {
                            fileOk = true;
                        }

                        if (fileOk)
                        {
                            string nombreImg = FileUploadArticulo.FileName.ToString();
                            FileUploadArticulo.PostedFile.SaveAs(ruta + nombreImg);
                            HiddenField1.Value = "/Imagenes/ImagenesArticulos/" + nombreImg;
                            respuesta = "subida";
                        }
                        else
                        {
                            HiddenField1.Value = "/Imagenes/Articulos.png";
                            respuesta = "Error";
                        }
                    }
                }
                else
                {
                    HiddenField1.Value = "/Imagenes/Articulos.png";
                    respuesta = "Error";
                }
                return respuesta;
            }
            catch (Exception)
            {
                
                return respuesta;
            }
        }
        #endregion

        //agregado garantia
        #region LLenar Cajas de Texto En Edicion
        public void LlenarCajasTexto(int i)
        {
            ClassNegArticulo artic = new ClassNegArticulo();
            var pro = artic.MuestraArticuloPorID(i);
            txtCodigo.Text = pro.ID_Articulo.ToString();
            txtNombre.Text = pro.Nombre_Articulo;
            txtdescripcion.Text = pro.Descripcion;
            DropCategoria.SelectedValue = pro.ID_Articulo.ToString();
            DropProveedor.SelectedValue = pro.ID_Proveedor.ToString();
            DropMarca.SelectedValue = pro.ID_Marca.ToString();
            chkEstado.Checked = Convert.ToBoolean(pro.Estado);
            Preview.ImageUrl = "~/" + pro.RutaImagen;
            DropGarantia.SelectedValue = pro.Garantia;
        }
        #endregion

        #region Limpiar Controles
        public void LimpiarControles()
        {
            txtNombre.Text = "";
            txtdescripcion.Text = "";
        }
        #endregion

        //agregado garantia
        #region Actualizar Articulos refencia la btn Actualizar
        public bool ActualizarArticulos()
        {
            var art = new ClassEntArticulo();
            art.ID_Articulo = Convert.ToInt32(txtCodigo.Text);
            art.Nombre_Articulo = txtNombre.Text;
            art.Descripcion = txtdescripcion.Text;
            art.ID_Categoria = Convert.ToInt32(DropCategoria.Text);
            art.ID_Proveedor = Convert.ToInt32(DropProveedor.Text);
            art.ID_Marca = Convert.ToInt32(DropMarca.Text);
            art.Estado = chkEstado.Checked;
            RutaImage();
            art.RutaImagen = HiddenField1.Value;
            art.Garantia = DropGarantia.SelectedValue;

            var artActualiza = new ClassNegArticulo();
            bool Resp = artActualiza.ActualizaArticulo(art);
            return Resp;
        }
        #endregion

        //agregado garantia
        #region Guardar Articulo refenrecia a btnGuardar
        public bool Guardaarticulo()
        {
            ClassEntArticulo art = new ClassEntArticulo();
            art.Nombre_Articulo = txtNombre.Text;
            art.Descripcion = txtdescripcion.Text;
            art.ID_Categoria = Convert.ToInt32(DropCategoria.SelectedValue);
            art.ID_Proveedor = Convert.ToInt32(DropProveedor.SelectedValue);
            art.ID_Marca = Convert.ToInt32(DropMarca.SelectedValue);
            art.Estado = chkEstado.Checked;
            RutaImage();
            art.RutaImagen = HiddenField1.Value;
            art.Garantia = DropGarantia.SelectedValue;

            ClassNegArticulo artGuardar = new ClassNegArticulo();
            if (artGuardar.BuscaArticulosDuplicados(art).Count < 1)
            {
                bool Resp = artGuardar.GuardaArticulo(art);
                return Resp;
            }   
            else
             {
                 this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal( '"+art.Nombre_Articulo+"', 'No se pudo guardar', 'error');", true);
                 //LiteralMensaje.Text = "<div class='alert alert-danger' role='alert'>Ya existe un articulos con estas descripciones</div>";
                 return false;
             }  
        }
        #endregion
        #endregion
        //************************************************//

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDropCategoria();
                LlenarDropProveedor();
                LlenarDropMarca();
                LlenarGrid();
                llenargridinactivos();
                MultiViewArticulos.ActiveViewIndex = 0;
            }

        }

        //************************************************//
        #region Botones
        #region btn Actualizar
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            //ActualizarArticulos();
            //LimpiarControles();
            MultiViewArticulos.ActiveViewIndex = 0;
            if (ActualizarArticulos())
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exito!', 'Artículo Actualizado Exitosamente', 'success');", true);
                    LlenarGrid();
                    txtBuscar.Text = "";
                    RutaImage();
                }
            else
	            {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo Actualizar', 'error');", true);
	            }
            LimpiarControles();
        }
        #endregion
        //pendiente
        protected void btnVerCombo_Click(object sender, EventArgs e)
        {

        }

        #region btn Ir Lista
        protected void btnIrlista_Click(object sender, EventArgs e)
        {
            MultiViewArticulos.ActiveViewIndex = 0;
            LlenarGrid();
            txtBuscar.Text = "";
        }
        #endregion

        #region btn Guardar
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //Guardaarticulo();
            //LimpiarControles();
            MultiViewArticulos.ActiveViewIndex = 0;
            if (Guardaarticulo())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Exito!', 'Artículo Guardado Exitosamente', 'success');", true);
                LlenarGrid();
                txtBuscar.Text = "";
                RutaImage();
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'No se pudo guardar, ya Existe', 'error');", true);
            }
            LimpiarControles();
        }
        #endregion

        #region btn Agregar no se utiliza
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            MultiViewArticulos.ActiveViewIndex = 0;
            txtNombre.Text = "";
            txtdescripcion.Text = "";
            HiddenField1.Value = "/Imagenes/Articulos.png";
        }
        #endregion

        #region btn Buscar
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscaProductoxNombre(txtBuscar.Text);
        }
        #endregion
        #endregion


        //************************************************//
        #region Comandos Botones de la Grilla
        protected void GridViewArticulo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //defino la variable row para conocer el control tipo boton en la fila
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            //Se obtiene e indice de la fila en donde dimos click
            int indice = row.RowIndex;
            //Obtenemos el valor del campo de la tabla (ID) de donde dimos click
            int codigo = Convert.ToInt32(GridViewArticulo.DataKeys[indice].Value);

            ClassNegArticulo art = new ClassNegArticulo();
            ClassEntArticulo art1 = new ClassEntArticulo();
            if (e.CommandName == "cmdEditar")
            {
                art1 = art.MuestraArticuloPorID(codigo);
                txtCodigo.Text = art1.ID_Articulo.ToString();
                txtNombre.Text = art1.Nombre_Articulo;
                txtdescripcion.Text = art1.Descripcion;
                DropCategoria.SelectedValue = art1.ID_Categoria.ToString();
                DropProveedor.SelectedValue = art1.ID_Proveedor.ToString();
                DropMarca.SelectedValue = art1.ID_Marca.ToString();
                chkEstado.Checked = Convert.ToBoolean(art1.Estado);
                HiddenField1.Value = art1.RutaImagen;
                DropGarantia.SelectedValue = art1.Garantia;

                Preview.ImageUrl = HiddenField1.Value;

                MultiViewArticulos.ActiveViewIndex = 1;

                btnGuardar.Enabled = false;
                btnGuardar.Visible = false;

                btnActualizar.Enabled = true;
                btnActualizar.Visible = true;

                btncanactu.Enabled = true;
                btncanactu.Visible = true;
            }
            if (e.CommandName == "cmdEliminar")
            {
                art.DardeBaja(codigo);
                LlenarGrid();
                //llenargridinactivos();
                //bool resp = art.EliminaArticulo(codigo);
                //if (resp)
                //{
                //    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Advertencia!', 'Articulo Eliminado', 'warning');", true);
                //    LlenarGrid();
                //}
                //else
                //{
                //    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'Acurrio un problema, no se elimino', 'error');", true);
                //}
            }
        }

        protected void DropArto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewArticulo.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropArto");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...           
                GridViewArticulo.PageIndex = pageList.SelectedIndex;
                //------------------------------
                LlenarGrid();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        protected void GridViewArticulo_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GridViewArticulo.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("DropArto");

                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("lblArtoPageOf");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GridViewArticulo.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GridViewArticulo.PageIndex)
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
                    int currentPage = GridViewArticulo.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GridViewArticulo.PageCount.ToString();
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        protected void btncanactu_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            MultiViewArticulos.ActiveViewIndex = 0;
            txtBuscar.Text = "";
            btnActualizar.Visible = false;
            btncanactu.Visible = false;
            btnGuardar.Visible = true;
            btnGuardar.Enabled = true;
        }

        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            MultiViewArticulos.ActiveViewIndex = 1;
            btnActualizar.Visible = false;
            btncanactu.Visible = false;
            btnGuardar.Visible = true;
            txtNombre.Text = "";
            txtdescripcion.Text = "";
            btnGuardar.Enabled = true;
        }

        protected void btnactivos_Click(object sender, EventArgs e)
        {
            MultiViewArticulos.ActiveViewIndex = 0;
            LlenarGrid();
        }

        protected void btnnew_Click(object sender, EventArgs e)
        {
            MultiViewArticulos.ActiveViewIndex = 1;
        }

        protected void btnbuscainactivos_Click(object sender, EventArgs e)
        {
            BuscaXNombreInactivos(txtbuscainactivos.Text.Trim());
        }

        protected void GvInactivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //defino la variable row para conocer el control tipo boton en la fila
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            //Se obtiene e indice de la fila en donde dimos click
            int indice = row.RowIndex;
            //Obtenemos el valor del campo de la tabla (ID) de donde dimos click
            int codigo = Convert.ToInt32(GvInactivos.DataKeys[indice].Value);

            ClassNegArticulo art = new ClassNegArticulo();
            ClassEntArticulo art1 = new ClassEntArticulo();
            if (e.CommandName == "cmdrestaurar")
            {
                art.Restaurar(codigo);
                llenargridinactivos();
            }
            if (e.CommandName == "cmdexterminar")
            {
                bool resp = art.EliminaArticulo(codigo);
                if (resp)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Advertencia!', 'Artículo Eliminado', 'warning');", true);
                    llenargridinactivos();
                }    
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Error!', 'Acurrió un problema, no se eliminó', 'error');", true);
                }
            }
        }

        protected void dropinactivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GvInactivos.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("dropinactivos");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...           
                GvInactivos.PageIndex = pageList.SelectedIndex;
                //------------------------------
                llenargridinactivos();
            }
            catch (Exception)
            {
                //throw;
            }
        }

        protected void btninactivos_Click(object sender, EventArgs e)
        {
            MultiViewArticulos.ActiveViewIndex = 2;
            llenargridinactivos();
        }

        protected void GvInactivos_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow pagerRow = GvInactivos.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("dropinactivos");
                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("lblfininactivos");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GvInactivos.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GvInactivos.PageIndex)
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
                    int currentPage = GvInactivos.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GvInactivos.PageCount.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void CBGarantia_CheckedChanged(object sender, EventArgs e)
        {
            if (true)
            {
                //txtgarantia.Enabled = true;       
                DropGarantia.Enabled = true;
            }
        }
    }
}